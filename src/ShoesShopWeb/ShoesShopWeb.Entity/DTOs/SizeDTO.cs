using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.Entity.DTOs;

public class SizeDTO
{
    public int SizeId { get; set; }
    
    [Required(ErrorMessage = "Kích cỡ là bắt buộc")]
    [MaxLength(10, ErrorMessage = "Kích cỡ không quá 10 ký tự")]
    public string SizeValue { get; set; } = string.Empty;
    
    public bool IsActive { get; set; } = true;
}
