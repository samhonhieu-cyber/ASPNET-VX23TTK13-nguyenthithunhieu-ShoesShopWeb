using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;
using System.Security.Claims;

namespace ShoesShopWeb.Pages.Orders;

[Authorize]
public class MyOrdersModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<MyOrdersModel> _logger;

    public MyOrdersModel(IUnitOfWork unitOfWork, ILogger<MyOrdersModel> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public List<Order> Orders { get; set; } = new();

    public async Task OnGetAsync()
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(userId);
            Orders = orders.OrderByDescending(o => o.OrderDate).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading orders");
        }
    }
}
