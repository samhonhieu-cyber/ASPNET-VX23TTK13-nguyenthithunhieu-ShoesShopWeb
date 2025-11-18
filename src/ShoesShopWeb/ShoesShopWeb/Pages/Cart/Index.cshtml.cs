using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.ViewModels;
using System.Security.Claims;

namespace ShoesShopWeb.Pages.Cart;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(IUnitOfWork unitOfWork, ILogger<IndexModel> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public CartViewModel? Cart { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var cart = await _unitOfWork.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                // Create cart if not exists
                cart = new Entity.Models.Cart
                {
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow
                };
                await _unitOfWork.Carts.AddAsync(cart);
                await _unitOfWork.SaveChangesAsync();
            }

            var cartItems = await _unitOfWork.CartItems
                .FindAsync(ci => ci.CartId == cart.CartId);

            var items = new List<CartItemViewModel>();
            foreach (var item in cartItems)
            {
                var variant = await _unitOfWork.ProductVariants.GetByIdAsync(item.VariantId);
                if (variant != null)
                {
                    var product = await _unitOfWork.Products.GetByIdAsync(variant.ProductId);
                    var size = await _unitOfWork.Sizes.GetByIdAsync(variant.SizeId);
                    var color = await _unitOfWork.Colors.GetByIdAsync(variant.ColorId);

                    items.Add(new CartItemViewModel
                    {
                        CartItemId = item.CartItemId,
                        CartId = item.CartId,
                        VariantId = item.VariantId,
                        Quantity = item.Quantity,
                        UnitPrice = variant.Price,
                        TotalPrice = variant.Price * item.Quantity,
                        ProductName = product?.ProductName ?? "",
                        ProductImage = product?.ImageUrl,
                        SizeValue = size?.SizeValue ?? "",
                        ColorName = color?.ColorName ?? "",
                        StockQuantity = variant.StockQuantity
                    });
                }
            }

            Cart = new CartViewModel
            {
                CartId = cart.CartId,
                UserId = cart.UserId,
                Items = items,
                TotalAmount = items.Sum(i => i.TotalPrice)
            };

            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading cart");
            return Page();
        }
    }

    public async Task<IActionResult> OnPostAddToCartAsync([FromBody] AddToCartRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var cart = await _unitOfWork.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Entity.Models.Cart
                {
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow
                };
                await _unitOfWork.Carts.AddAsync(cart);
                await _unitOfWork.SaveChangesAsync();
            }

            // Check if item already exists
            var existingItem = (await _unitOfWork.CartItems
                .FindAsync(ci => ci.CartId == cart.CartId && ci.VariantId == request.VariantId))
                .FirstOrDefault();

            if (existingItem != null)
            {
                existingItem.Quantity += request.Quantity;
                _unitOfWork.CartItems.Update(existingItem);
            }
            else
            {
                var cartItem = new Entity.Models.CartItem
                {
                    CartId = cart.CartId,
                    VariantId = request.VariantId,
                    Quantity = request.Quantity,
                    AddedAt = DateTime.UtcNow
                };
                await _unitOfWork.CartItems.AddAsync(cartItem);
            }

            await _unitOfWork.SaveChangesAsync();

            return new JsonResult(new { success = true, message = "Đã thêm vào giỏ hàng" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding to cart");
            return new JsonResult(new { success = false, message = "Có lỗi xảy ra" });
        }
    }

    public async Task<IActionResult> OnPostRemoveFromCartAsync([FromBody] RemoveFromCartRequest request)
    {
        try
        {
            var cartItem = await _unitOfWork.CartItems.GetByIdAsync(request.CartItemId);
            if (cartItem != null)
            {
                _unitOfWork.CartItems.Delete(cartItem);
                await _unitOfWork.SaveChangesAsync();
            }

            return new JsonResult(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing from cart");
            return new JsonResult(new { success = false, message = "Có lỗi xảy ra" });
        }
    }

    public async Task<IActionResult> OnPostUpdateQuantityAsync([FromBody] UpdateQuantityRequest request)
    {
        try
        {
            var cartItem = await _unitOfWork.CartItems.GetByIdAsync(request.CartItemId);
            if (cartItem != null && request.Quantity > 0)
            {
                cartItem.Quantity = request.Quantity;
                _unitOfWork.CartItems.Update(cartItem);
                await _unitOfWork.SaveChangesAsync();
            }

            return new JsonResult(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating quantity");
            return new JsonResult(new { success = false, message = "Có lỗi xảy ra" });
        }
    }

    public async Task<IActionResult> OnGetGetCartCountAsync()
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var cart = await _unitOfWork.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return new JsonResult(new { count = 0 });
            }

            var items = await _unitOfWork.CartItems.FindAsync(ci => ci.CartId == cart.CartId);
            var count = items.Sum(i => i.Quantity);

            return new JsonResult(new { count });
        }
        catch
        {
            return new JsonResult(new { count = 0 });
        }
    }
}

public class AddToCartRequest
{
    public int VariantId { get; set; }
    public int Quantity { get; set; }
}

public class RemoveFromCartRequest
{
    public int CartItemId { get; set; }
}

public class UpdateQuantityRequest
{
    public int CartItemId { get; set; }
    public int Quantity { get; set; }
}
