using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Enums;
using ShoesShopWeb.Entity.Models;
using System.Security.Claims;

namespace ShoesShopWeb.Pages.Orders;

[Authorize]
public class OrderConfirmationModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<OrderConfirmationModel> _logger;

    public OrderConfirmationModel(IUnitOfWork unitOfWork, ILogger<OrderConfirmationModel> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public Order? Order { get; set; }

    public async Task<IActionResult> OnGetAsync(int orderId)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            // Load order with all details
            Order = await _unitOfWork.Orders.GetOrderWithDetailsAsync(orderId);

            if (Order == null || Order.UserId != userId)
            {
                _logger.LogWarning($"Order {orderId} not found for user {userId}");
                return Page();
            }

            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error loading order confirmation for order {orderId}");
            return Page();
        }
    }

    public async Task<IActionResult> OnPostConfirmPaymentAsync(int orderId)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            // Load order
            var order = await _unitOfWork.Orders.FirstOrDefaultAsync(
                o => o.OrderId == orderId && o.UserId == userId
            );

            if (order == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy đơn hàng";
                return RedirectToPage("/Orders/MyOrders");
            }

            if (order.Status != OrderStatus.Pending)
            {
                TempData["ErrorMessage"] = "Đơn hàng không ở trạng thái chờ thanh toán";
                return RedirectToPage("/Orders/OrderConfirmation", new { orderId });
            }

            // Update order status to Processing (Đã xác nhận)
            order.Status = OrderStatus.Processing;
            order.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Xác nhận thanh toán thành công! Đơn hàng của bạn đang được xử lý.";
            
            return RedirectToPage("/Orders/OrderConfirmation", new { orderId });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error confirming payment for order {orderId}");
            TempData["ErrorMessage"] = "Có lỗi xảy ra khi xác nhận thanh toán. Vui lòng thử lại.";
            return RedirectToPage("/Orders/OrderConfirmation", new { orderId });
        }
    }
}
