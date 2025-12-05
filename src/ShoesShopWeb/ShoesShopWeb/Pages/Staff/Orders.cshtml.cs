using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Enums;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.Pages.Staff;

[Authorize(Roles = "Admin,Staff")]
public class OrdersModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<OrdersModel> _logger;

    public OrdersModel(IUnitOfWork unitOfWork, ILogger<OrdersModel> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public IEnumerable<Order> Orders { get; set; } = new List<Order>();

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            Orders = await _unitOfWork.Orders.GetAllAsync();
            
            // Load users
            foreach (var order in Orders)
            {
                order.User = (await _unitOfWork.Users.GetByIdAsync(order.UserId))!;
            }
            
            // Sort by most recent first
            Orders = Orders.OrderByDescending(o => o.OrderDate);
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading orders");
            return Page();
        }
    }

    public async Task<IActionResult> OnGetGetOrderAsync(int id)
    {
        try
        {
            var order = await _unitOfWork.Orders.GetOrderWithDetailsAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var items = order.OrderItems?.Select(item => new
            {
                productName = item.ProductVariant?.Product?.ProductName ?? "",
                imageUrl = item.ProductVariant?.Product?.ImageUrl ?? "",
                size = item.ProductVariant?.Size?.SizeValue ?? "",
                color = item.ProductVariant?.Color?.ColorName ?? "",
                quantity = item.Quantity,
                unitPrice = item.UnitPrice,
                subtotal = item.Subtotal
            }).ToList();

            return new JsonResult(new
            {
                orderId = order.OrderId,
                orderNumber = order.OrderNumber,
                orderDate = order.OrderDate,
                status = (int)order.Status,
                customerName = order.User?.FullName ?? "",
                phoneNumber = order.PhoneNumber,
                shippingAddress = order.ShippingAddress,
                note = order.Note,
                totalAmount = order.TotalAmount,
                items = items
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting order {id}");
            return BadRequest();
        }
    }

    public async Task<IActionResult> OnPostUpdateStatusAsync(int id, OrderStatus status)
    {
        try
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            // Validate status transition
            if (!IsValidStatusTransition(order.Status, status))
            {
                TempData["ErrorMessage"] = "Không thể chuyển trạng thái đơn hàng này";
                return RedirectToPage();
            }

            order.Status = status;
            order.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Cập nhật trạng thái đơn hàng thành công!";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error updating order status {id}");
            TempData["ErrorMessage"] = "Lỗi khi cập nhật trạng thái đơn hàng";
            return RedirectToPage();
        }
    }

    private bool IsValidStatusTransition(OrderStatus currentStatus, OrderStatus newStatus)
    {
        // Define valid transitions
        return (currentStatus, newStatus) switch
        {
            (OrderStatus.Pending, OrderStatus.Processing) => true,
            (OrderStatus.Pending, OrderStatus.Cancelled) => true,
            (OrderStatus.Processing, OrderStatus.Shipping) => true,
            (OrderStatus.Processing, OrderStatus.Cancelled) => true,
            (OrderStatus.Shipping, OrderStatus.Delivered) => true,
            (OrderStatus.Shipping, OrderStatus.Cancelled) => true,
            _ => false
        };
    }
}
