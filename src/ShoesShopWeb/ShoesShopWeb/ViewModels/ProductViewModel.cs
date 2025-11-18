namespace ShoesShopWeb.ViewModels;

public class ProductViewModel
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<ProductVariantViewModel>? Variants { get; set; }
}

public class ProductVariantViewModel
{
    public int VariantId { get; set; }
    public int ProductId { get; set; }
    public int SizeId { get; set; }
    public string SizeValue { get; set; } = string.Empty;
    public int ColorId { get; set; }
    public string ColorName { get; set; } = string.Empty;
    public string? ColorHexCode { get; set; }
    public int StockQuantity { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
}
