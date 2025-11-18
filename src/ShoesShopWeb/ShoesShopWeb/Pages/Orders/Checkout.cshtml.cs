using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Enums;
using ShoesShopWeb.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ShoesShopWeb.Pages.Orders;

[Authorize]
public class CheckoutModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CheckoutModel> _logger;

    public CheckoutModel(IUnitOfWork unitOfWork, ILogger<CheckoutModel> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public CartViewModel Cart { get; set; } = new();

    public class InputModel
    {
        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Địa chỉ giao hàng là bắt buộc")]
        [StringLength(500, ErrorMessage = "Địa chỉ không được vượt quá 500 ký tự")]
        [Display(Name = "Địa chỉ giao hàng")]
        public string ShippingAddress { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự")]
        [Display(Name = "Ghi chú")]
        public string? Note { get; set; }
    }

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            
            // Load user info
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                return RedirectToPage("/Account/Login");
            }

            // Pre-fill form with user info
            Input = new InputModel
            {
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                ShippingAddress = user.Address ?? string.Empty
            };

            // Load cart
            await LoadCartAsync(userId);

            if (!Cart.Items.Any())
            {
                return Page();
            }

            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading checkout page");
            return Page();
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // Reload cart
        await LoadCartAsync(userId);

        if (!Cart.Items.Any())
        {
            ModelState.AddModelError(string.Empty, "Giỏ hàng trống");
            return Page();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            await _unitOfWork.BeginTransactionAsync();

            // Generate order number
            var orderNumber = $"ORD{DateTime.UtcNow:yyyyMMddHHmmss}";

            // Create order with Pending status
            var order = new Entity.Models.Order
            {
                OrderNumber = orderNumber,
                UserId = userId,
                TotalAmount = Cart.TotalAmount,
                Status = OrderStatus.Pending, // Chờ thanh toán
                ShippingAddress = Input.ShippingAddress,
                PhoneNumber = Input.PhoneNumber,
                Note = Input.Note,
                OrderDate = DateTime.UtcNow
            };

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            // Create order items from cart
            var cart = await _unitOfWork.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            var cartItems = await _unitOfWork.CartItems.FindAsync(ci => ci.CartId == cart!.CartId);

            foreach (var cartItem in cartItems)
            {
                var variant = await _unitOfWork.ProductVariants.GetByIdAsync(cartItem.VariantId);
                if (variant != null)
                {
                    var orderItem = new Entity.Models.OrderItem
                    {
                        OrderId = order.OrderId,
                        VariantId = cartItem.VariantId,
                        Quantity = cartItem.Quantity,
                        UnitPrice = variant.Price,
                        Subtotal = variant.Price * cartItem.Quantity
                    };

                    await _unitOfWork.OrderItems.AddAsync(orderItem);

                    // Update stock
                    variant.StockQuantity -= cartItem.Quantity;
                    _unitOfWork.ProductVariants.Update(variant);
                }
            }

            // Clear cart
            _unitOfWork.CartItems.DeleteRange(cartItems);
            
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();

            TempData["SuccessMessage"] = "Đặt hàng thành công!";
            TempData["OrderId"] = order.OrderId;

            return RedirectToPage("/Orders/OrderConfirmation", new { orderId = order.OrderId });
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync();
            _logger.LogError(ex, "Error creating order");
            ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi đặt hàng. Vui lòng thử lại.");
            return Page();
        }
    }

    private async Task LoadCartAsync(int userId)
    {
        var cart = await _unitOfWork.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            Cart = new CartViewModel();
            return;
        }

        var cartItems = await _unitOfWork.CartItems.FindAsync(ci => ci.CartId == cart.CartId);

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
    }
}
