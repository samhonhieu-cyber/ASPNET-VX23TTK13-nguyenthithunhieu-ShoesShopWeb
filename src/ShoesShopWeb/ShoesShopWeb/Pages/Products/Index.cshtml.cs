using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.BLL.Interfaces;
using ShoesShopWeb.ViewModels;

namespace ShoesShopWeb.Pages.Products;

public class IndexModel : PageModel
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly ISizeService _sizeService;
    private readonly IColorService _colorService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        IProductService productService,
        ICategoryService categoryService,
        ISizeService sizeService,
        IColorService colorService,
        ILogger<IndexModel> logger)
    {
        _productService = productService;
        _categoryService = categoryService;
        _sizeService = sizeService;
        _colorService = colorService;
        _logger = logger;
    }

    public List<ProductViewModel> Products { get; set; } = new();
    public List<CategoryViewModel> Categories { get; set; } = new();
    public List<SizeViewModel> Sizes { get; set; } = new();
    public List<ColorViewModel> Colors { get; set; } = new();
    
    public string? Keyword { get; set; }
    public int? CategoryId { get; set; }
    public List<int>? SizeIds { get; set; }
    public List<int>? ColorIds { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? SortBy { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 12;
    public int TotalProducts { get; set; }
    public int TotalPages { get; set; }

    public async Task OnGetAsync(
        string? keyword,
        int? categoryId,
        List<int>? sizeIds,
        List<int>? colorIds,
        decimal? minPrice,
        decimal? maxPrice,
        string? sortBy,
        int pageNumber = 1,
        int pageSize = 12)
    {
        try
        {
            // Set filter properties
            Keyword = keyword;
            CategoryId = categoryId;
            SizeIds = sizeIds;
            ColorIds = colorIds;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            SortBy = sortBy;
            PageNumber = pageNumber;
            PageSize = pageSize;

            // Get categories, sizes, colors for filter options
            var categories = await _categoryService.GetAllActiveCategoriesAsync();
            var sizes = await _sizeService.GetActiveSizesAsync();
            var colors = await _colorService.GetActiveColorsAsync();

            var (products, totalCount) = await _productService.GetProductsWithFiltersAsync(
                keyword,
                categoryId,
                sizeIds,
                colorIds,
                minPrice,
                maxPrice,
                sortBy,
                pageNumber,
                pageSize);

            Products = products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                BasePrice = p.BasePrice,
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.CategoryName ?? "",
                IsActive = p.IsActive
            }).ToList();

            Categories = categories.Select(c => new CategoryViewModel
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description,
                IsActive = c.IsActive
            }).ToList();

            Sizes = sizes.Select(s => new SizeViewModel
            {
                SizeId = s.SizeId,
                SizeValue = s.SizeValue
            }).ToList();

            Colors = colors.Select(c => new ColorViewModel
            {
                ColorId = c.ColorId,
                ColorName = c.ColorName,
                ColorHexCode = c.ColorCode
            }).ToList();

            TotalProducts = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading products");
        }
    }
}
