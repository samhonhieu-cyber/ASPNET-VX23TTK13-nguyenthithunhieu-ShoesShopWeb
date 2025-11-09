using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.Entity.DTOs;

public class ColorDTO
{
    public int ColorId { get; set; }
    
    [Required(ErrorMessage = "Tên màu là bắt buộc")]
    [MaxLength(50, ErrorMessage = "Tên màu không quá 50 ký tự")]
    public string ColorName { get; set; } = string.Empty;
    
    [MaxLength(7, ErrorMessage = "Mã màu không quá 7 ký tự")]
    public string? ColorCode { get; set; }
    
    public bool IsActive { get; set; } = true;
}
