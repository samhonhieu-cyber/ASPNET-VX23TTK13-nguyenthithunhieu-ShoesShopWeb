using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.BLL.Interfaces;

namespace ShoesShopWeb.Pages.Staff;

[Authorize(Roles = "Staff,Admin")]
public class IndexModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IUserService _userService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        IProductService productService,
        ICategoryService categoryService,
        IUserService userService,
        ILogger<IndexModel> logger)
    {
        _productService = productService;
        _categoryService = categoryService;
        _userService = userService;
        _logger = logger;
    }

    public int TotalProducts { get; set; }
    public int TotalCategories { get; set; }
    public int TotalCustomers { get; set; }
    public int ActiveProducts { get; set; }
    public int ActiveCategories { get; set; }

    public async Task OnGetAsync()
    {
        try
        {
            // Load basic dashboard statistics
            var allProducts = await _productService.GetAllProductsAsync();
            var allCategories = await _categoryService.GetAllCategoriesAsync();
            var allCustomers = await _userService.GetAllCustomersAsync();
            
            TotalProducts = allProducts.Count();
            TotalCategories = allCategories.Count();
            TotalCustomers = allCustomers.Count;
            ActiveProducts = allProducts.Count(p => p.IsActive);
            ActiveCategories = allCategories.Count(c => c.IsActive);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading dashboard");
        }
    }
}
