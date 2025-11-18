using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.Pages.Staff;

[Authorize(Roles = "Admin,Staff")]
public class ProductVariantsModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductVariantsModel> _logger;

    public ProductVariantsModel(IUnitOfWork unitOfWork, ILogger<ProductVariantsModel> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    public int ProductId { get; set; }

    public Product? Product { get; set; }
    public IEnumerable<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    public IEnumerable<Color> Colors { get; set; } = new List<Color>();
    public IEnumerable<Size> Sizes { get; set; } = new List<Size>();

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            Product = await _unitOfWork.Products.GetByIdAsync(ProductId);
            if (Product == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy sản phẩm";
                return RedirectToPage("/Staff/Products");
            }

            Variants = await _unitOfWork.ProductVariants.FindAsync(v => v.ProductId == ProductId);
            
            // Load related data for variants
            foreach (var variant in Variants)
            {
                variant.Color = await _unitOfWork.Colors.GetByIdAsync(variant.ColorId);
                variant.Size = await _unitOfWork.Sizes.GetByIdAsync(variant.SizeId);
            }

            Colors = await _unitOfWork.Colors.FindAsync(c => c.IsActive);
            Sizes = await _unitOfWork.Sizes.FindAsync(s => s.IsActive);

            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error loading product variants for product {ProductId}");
            return Page();
        }
    }

    public async Task<IActionResult> OnGetGetVariantAsync(int id)
    {
        try
        {
            var variant = await _unitOfWork.ProductVariants.GetByIdAsync(id);
            if (variant == null)
            {
                return NotFound();
            }

            return new JsonResult(new
            {
                variantId = variant.VariantId,
                productId = variant.ProductId,
                colorId = variant.ColorId,
                sizeId = variant.SizeId,
                sku = variant.SKU,
                price = variant.Price,
                stockQuantity = variant.StockQuantity,
                isActive = variant.IsActive
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting variant {id}");
            return BadRequest();
        }
    }

    public async Task<IActionResult> OnPostCreateAsync(
        int productId,
        int colorId,
        int sizeId,
        string? sku,
        decimal price,
        int stockQuantity,
        bool isActive = true)
    {
        try
        {
            // Check if variant already exists
            var existingVariant = await _unitOfWork.ProductVariants.FirstOrDefaultAsync(
                v => v.ProductId == productId && v.ColorId == colorId && v.SizeId == sizeId
            );

            if (existingVariant != null)
            {
                return BadRequest("Biến thể này đã tồn tại (cùng sản phẩm, màu và size)");
            }

            // Auto-generate SKU if not provided
            if (string.IsNullOrEmpty(sku))
            {
                sku = $"PRD{productId}-CLR{colorId}-SZ{sizeId}";
            }

            var variant = new ProductVariant
            {
                ProductId = productId,
                ColorId = colorId,
                SizeId = sizeId,
                SKU = sku,
                Price = price,
                StockQuantity = stockQuantity,
                IsActive = isActive,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.ProductVariants.AddAsync(variant);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Thêm biến thể thành công!";
            return RedirectToPage(new { productId });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating variant");
            return BadRequest("Lỗi khi thêm biến thể");
        }
    }

    public async Task<IActionResult> OnPostUpdateAsync(
        int variantId,
        int productId,
        int colorId,
        int sizeId,
        string? sku,
        decimal price,
        int stockQuantity,
        bool isActive = true)
    {
        try
        {
            var variant = await _unitOfWork.ProductVariants.GetByIdAsync(variantId);
            if (variant == null)
            {
                return NotFound();
            }

            // Check if another variant with same attributes exists
            var existingVariant = await _unitOfWork.ProductVariants.FirstOrDefaultAsync(
                v => v.VariantId != variantId && 
                     v.ProductId == productId && 
                     v.ColorId == colorId && 
                     v.SizeId == sizeId
            );

            if (existingVariant != null)
            {
                return BadRequest("Biến thể này đã tồn tại (cùng sản phẩm, màu và size)");
            }

            variant.ColorId = colorId;
            variant.SizeId = sizeId;
            variant.SKU = sku ?? $"PRD{productId}-CLR{colorId}-SZ{sizeId}";
            variant.Price = price;
            variant.StockQuantity = stockQuantity;
            variant.IsActive = isActive;
            variant.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.ProductVariants.Update(variant);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Cập nhật biến thể thành công!";
            return RedirectToPage(new { productId });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error updating variant {variantId}");
            return BadRequest("Lỗi khi cập nhật biến thể");
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        try
        {
            var variant = await _unitOfWork.ProductVariants.GetByIdAsync(id);
            if (variant == null)
            {
                return NotFound();
            }

            var productId = variant.ProductId;

            // Check if variant is used in orders
            var orderItems = await _unitOfWork.OrderItems.FindAsync(oi => oi.VariantId == id);
            if (orderItems.Any())
            {
                return BadRequest("Không thể xóa biến thể đã có trong đơn hàng");
            }

            // Check if variant is in any cart
            var cartItems = await _unitOfWork.CartItems.FindAsync(ci => ci.VariantId == id);
            if (cartItems.Any())
            {
                // Remove from carts first
                _unitOfWork.CartItems.DeleteRange(cartItems);
            }

            _unitOfWork.ProductVariants.Delete(variant);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Xóa biến thể thành công!";
            return RedirectToPage(new { productId });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error deleting variant {id}");
            return BadRequest("Lỗi khi xóa biến thể");
        }
    }
}
