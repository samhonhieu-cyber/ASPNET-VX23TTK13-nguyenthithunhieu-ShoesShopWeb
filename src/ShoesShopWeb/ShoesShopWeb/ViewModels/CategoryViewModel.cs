using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.ViewModels;

public class CategoryViewModel
{
    public int CategoryId { get; set; }
    
    [Required(ErrorMessage = "Tên danh mục là bắt buộc")]
    [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự")]
    [Display(Name = "Tên danh mục")]
    public string CategoryName { get; set; } = string.Empty;
    
    [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
    [Display(Name = "Mô tả")]
    public string? Description { get; set; }
    
    [Display(Name = "Hoạt động")]
    public bool IsActive { get; set; } = true;
    
    public int ProductCount { get; set; }
}
