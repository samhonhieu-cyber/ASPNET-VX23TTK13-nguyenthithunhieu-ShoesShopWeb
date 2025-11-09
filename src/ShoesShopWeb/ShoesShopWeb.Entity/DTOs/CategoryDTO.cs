using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.Entity.DTOs;

public class CategoryDTO
{
    public int CategoryId { get; set; }
    
    [Required(ErrorMessage = "Tên danh mục là bắt buộc")]
    [MaxLength(100, ErrorMessage = "Tên danh mục không quá 100 ký tự")]
    public string CategoryName { get; set; } = string.Empty;
    
    [MaxLength(500, ErrorMessage = "Mô tả không quá 500 ký tự")]
    public string? Description { get; set; }
    
    public bool IsActive { get; set; } = true;
}
