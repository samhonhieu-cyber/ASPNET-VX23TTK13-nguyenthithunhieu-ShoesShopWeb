using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.Entity.DTOs;

public class CategoryDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public int ProductCount { get; set; }
}

public class CategoryCreateDto
{
    [Required(ErrorMessage = "Tên danh mục không được để trống")]
    [MaxLength(100)]
    public string CategoryName { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Description { get; set; }
}

public class CategoryUpdateDto
{
    [Required]
    [MaxLength(100)]
    public string CategoryName { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    public bool IsActive { get; set; }
}
