using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.Entity.DTOs;

public class ProductDTO
{
    public int ProductId { get; set; }
    
    [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
    [MaxLength(200, ErrorMessage = "Tên sản phẩm không quá 200 ký tự")]
    public string ProductName { get; set; } = string.Empty;
    
    [MaxLength(1000, ErrorMessage = "Mô tả không quá 1000 ký tự")]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Giá cơ bản là bắt buộc")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
    public decimal BasePrice { get; set; }
    
    public string? ImageUrl { get; set; }
    
    [Required(ErrorMessage = "Danh mục là bắt buộc")]
    public int CategoryId { get; set; }
    
    public string? CategoryName { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    public List<ProductVariantDTO>? Variants { get; set; }
}
