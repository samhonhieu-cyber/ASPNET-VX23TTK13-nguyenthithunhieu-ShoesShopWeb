using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.Entity.DTOs;

public class ProductDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ProductCreateDto
{
    [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
    [MaxLength(200)]
    public string ProductName { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
    public decimal BasePrice { get; set; }
    
    [Required(ErrorMessage = "Danh mục không được để trống")]
    public int CategoryId { get; set; }
    
    [MaxLength(500)]
    public string? ImageUrl { get; set; }
}

public class ProductUpdateDto
{
    [Required]
    [MaxLength(200)]
    public string ProductName { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal BasePrice { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
    
    [MaxLength(500)]
    public string? ImageUrl { get; set; }
    
    public bool IsActive { get; set; }
}
