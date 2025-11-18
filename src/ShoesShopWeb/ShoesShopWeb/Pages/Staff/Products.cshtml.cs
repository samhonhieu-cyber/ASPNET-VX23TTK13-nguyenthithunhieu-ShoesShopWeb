using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.Pages.Staff;

[Authorize(Roles = "Admin,Staff")]
public class ProductsModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductsModel> _logger;

    public ProductsModel(IUnitOfWork unitOfWork, ILogger<ProductsModel> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public IEnumerable<Product> Products { get; set; } = new List<Product>();
    public IEnumerable<Category> Categories { get; set; } = new List<Category>();

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            Products = await _unitOfWork.Products.GetAllAsync();
            
            // Load related data
            foreach (var product in Products)
            {
                product.Category = await _unitOfWork.Categories.GetByIdAsync(product.CategoryId);
                product.ProductVariants = (await _unitOfWork.ProductVariants.FindAsync(v => v.ProductId == product.ProductId)).ToList();
            }
            
            Categories = await _unitOfWork.Categories.GetAllAsync();
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading products");
            return Page();
        }
    }

    public async Task<IActionResult> OnGetGetProductAsync(int id)
    {
        try
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return new JsonResult(new
            {
                productId = product.ProductId,
                productName = product.ProductName,
                description = product.Description,
                categoryId = product.CategoryId,
                basePrice = product.BasePrice,
                imageUrl = product.ImageUrl,
                isActive = product.IsActive
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting product {id}");
            return BadRequest();
        }
    }

    public async Task<IActionResult> OnPostCreateAsync(
        string productName,
        string? description,
        int categoryId,
        decimal basePrice,
        string? imageUrl,
        bool isActive = true)
    {
        try
        {
            var product = new Product
            {
                ProductName = productName,
                Description = description,
                CategoryId = categoryId,
                BasePrice = basePrice,
                ImageUrl = imageUrl,
                IsActive = isActive,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Thêm sản phẩm thành công!";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating product");
            TempData["ErrorMessage"] = "Lỗi khi thêm sản phẩm";
            return RedirectToPage();
        }
    }

    public async Task<IActionResult> OnPostUpdateAsync(
        int productId,
        string productName,
        string? description,
        int categoryId,
        decimal basePrice,
        string? imageUrl,
        bool isActive = true)
    {
        try
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy sản phẩm";
                return RedirectToPage();
            }

            product.ProductName = productName;
            product.Description = description;
            product.CategoryId = categoryId;
            product.BasePrice = basePrice;
            product.ImageUrl = imageUrl;
            product.IsActive = isActive;
            product.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Cập nhật sản phẩm thành công!";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error updating product {productId}");
            TempData["ErrorMessage"] = "Lỗi khi cập nhật sản phẩm";
            return RedirectToPage();
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        try
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Check if product has variants
            var variants = await _unitOfWork.ProductVariants.FindAsync(v => v.ProductId == id);
            if (variants.Any())
            {
                TempData["ErrorMessage"] = "Không thể xóa sản phẩm có biến thể. Vui lòng xóa biến thể trước.";
                return RedirectToPage();
            }

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Xóa sản phẩm thành công!";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error deleting product {id}");
            TempData["ErrorMessage"] = "Lỗi khi xóa sản phẩm";
            return RedirectToPage();
        }
    }
}
