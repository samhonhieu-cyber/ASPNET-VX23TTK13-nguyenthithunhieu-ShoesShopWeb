using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.BLL.Interfaces;
using ShoesShopWeb.ViewModels;

namespace ShoesShopWeb.Pages.Products;

public class DetailsModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ILogger<DetailsModel> _logger;

    public DetailsModel(IProductService productService, ILogger<DetailsModel> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    public ProductViewModel Product { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        try
        {
            var product = await _productService.GetProductWithDetailsAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            Product = new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                BasePrice = product.BasePrice,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.CategoryName ?? "",
                IsActive = product.IsActive,
                Variants = product.ProductVariants?.Select(v => new ProductVariantViewModel
                {
                    VariantId = v.VariantId,
                    ProductId = v.ProductId,
                    SizeId = v.SizeId,
                    SizeValue = v.Size?.SizeValue ?? "",
                    ColorId = v.ColorId,
                    ColorName = v.Color?.ColorName ?? "",
                    ColorHexCode = v.Color?.ColorCode,
                    StockQuantity = v.StockQuantity,
                    Price = v.Price,
                    IsAvailable = v.IsAvailable
                }).ToList()
            };

            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error loading product details for id {id}");
            return NotFound();
        }
    }
}
