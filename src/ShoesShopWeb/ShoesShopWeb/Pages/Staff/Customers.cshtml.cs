using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Enums;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.Pages.Staff;

[Authorize(Roles = "Admin,Staff")]
public class CustomersModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CustomersModel> _logger;

    public CustomersModel(IUnitOfWork unitOfWork, ILogger<CustomersModel> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public IEnumerable<User> Customers { get; set; } = new List<User>();

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            // Get all customers (excluding staff/admin)
            var allUsers = await _unitOfWork.Users.GetAllAsync();
            Customers = allUsers.Where(u => u.Role == UserRole.Customer);
            
            // Load orders for each customer
            foreach (var customer in Customers)
            {
                customer.Orders = (await _unitOfWork.Orders.FindAsync(o => o.UserId == customer.UserId)).ToList();
            }
            
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading customers");
            return Page();
        }
    }

    public async Task<IActionResult> OnGetGetCustomerAsync(int id)
    {
        try
        {
            var customer = await _unitOfWork.Users.GetByIdAsync(id);
            if (customer == null || customer.Role != UserRole.Customer)
            {
                return NotFound();
            }

            var orders = await _unitOfWork.Orders.FindAsync(o => o.UserId == id);
            var orderCount = orders.Count();
            var totalSpent = orders.Sum(o => o.TotalAmount);

            return new JsonResult(new
            {
                userId = customer.UserId,
                fullName = customer.FullName,
                email = customer.Email,
                phoneNumber = customer.PhoneNumber,
                address = customer.Address,
                isActive = customer.IsActive,
                createdAt = customer.CreatedAt,
                orderCount = orderCount,
                totalSpent = totalSpent
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting customer {id}");
            return BadRequest();
        }
    }

    public async Task<IActionResult> OnPostToggleStatusAsync(int id, bool status)
    {
        try
        {
            var customer = await _unitOfWork.Users.GetByIdAsync(id);
            if (customer == null || customer.Role != UserRole.Customer)
            {
                return NotFound();
            }

            customer.IsActive = status;
            customer.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Users.Update(customer);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = status 
                ? "Kích hoạt khách hàng thành công!" 
                : "Vô hiệu hóa khách hàng thành công!";
            
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error toggling customer status {id}");
            return BadRequest();
        }
    }
}
