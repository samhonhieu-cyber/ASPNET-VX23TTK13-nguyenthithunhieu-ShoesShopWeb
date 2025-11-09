namespace ShoesShopWeb.Entity.DTOs;

public class CartItemDTO
{
    public int CartItemId { get; set; }
    public int VariantId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ColorName { get; set; } = string.Empty;
    public string SizeValue { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
    public string? ImageUrl { get; set; }
    public int StockQuantity { get; set; }
}
