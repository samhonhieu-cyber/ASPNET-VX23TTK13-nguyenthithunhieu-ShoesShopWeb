using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.Entity.DTOs;

public class ProductVariantDTO
{
    public int VariantId { get; set; }
    
    [Required(ErrorMessage = "Sản phẩm là bắt buộc")]
    public int ProductId { get; set; }
    
    public string? ProductName { get; set; }
    
    [Required(ErrorMessage = "Màu sắc là bắt buộc")]
    public int ColorId { get; set; }
    
    public string? ColorName { get; set; }
    public string? ColorCode { get; set; }
    
    [Required(ErrorMessage = "Kích cỡ là bắt buộc")]
    public int SizeId { get; set; }
    
    public string? SizeValue { get; set; }
    
    [Required(ErrorMessage = "Giá là bắt buộc")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Số lượng tồn kho là bắt buộc")]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng không được âm")]
    public int StockQuantity { get; set; }
    
    [MaxLength(20, ErrorMessage = "SKU không quá 20 ký tự")]
    public string? SKU { get; set; }
    
    public bool IsActive { get; set; } = true;
}
