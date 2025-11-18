namespace ShoesShopWeb.ViewModels;

public class CartViewModel
{
    public int CartId { get; set; }
    public int UserId { get; set; }
    public List<CartItemViewModel> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
}

public class CartItemViewModel
{
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public int VariantId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    
    // Product details
    public string ProductName { get; set; } = string.Empty;
    public string? ProductImage { get; set; }
    public string SizeValue { get; set; } = string.Empty;
    public string ColorName { get; set; } = string.Empty;
    public int StockQuantity { get; set; }
}

public class AddToCartViewModel
{
    public int VariantId { get; set; }
    public int Quantity { get; set; } = 1;
}
