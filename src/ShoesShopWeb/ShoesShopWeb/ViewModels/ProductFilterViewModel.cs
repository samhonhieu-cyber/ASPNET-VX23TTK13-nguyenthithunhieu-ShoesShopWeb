namespace ShoesShopWeb.ViewModels;

public class ProductFilterViewModel
{
    public string? Keyword { get; set; }
    public int? CategoryId { get; set; }
    public List<int>? SizeIds { get; set; }
    public List<int>? ColorIds { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? SortBy { get; set; } // price-asc, price-desc, name, newest
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 12;
}

public class ProductListViewModel
{
    public List<ProductViewModel> Products { get; set; } = new();
    public ProductFilterViewModel Filter { get; set; } = new();
    public int TotalProducts { get; set; }
    public int TotalPages { get; set; }
    public List<CategoryViewModel> Categories { get; set; } = new();
    public List<SizeViewModel> Sizes { get; set; } = new();
    public List<ColorViewModel> Colors { get; set; } = new();
}

public class SizeViewModel
{
    public int SizeId { get; set; }
    public string SizeValue { get; set; } = string.Empty;
}

public class ColorViewModel
{
    public int ColorId { get; set; }
    public string ColorName { get; set; } = string.Empty;
    public string? ColorHexCode { get; set; }
}
