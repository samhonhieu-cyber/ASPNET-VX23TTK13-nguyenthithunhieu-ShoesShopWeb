using System.ComponentModel.DataAnnotations;
using ShoesShopWeb.Entity.Enums;

namespace ShoesShopWeb.Entity.DTOs;

public class CreateOrderDTO
{
    [Required(ErrorMessage = "Địa chỉ giao hàng là bắt buộc")]
    [MaxLength(500, ErrorMessage = "Địa chỉ không quá 500 ký tự")]
    public string ShippingAddress { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    [MaxLength(20, ErrorMessage = "Số điện thoại không quá 20 ký tự")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [MaxLength(500, ErrorMessage = "Ghi chú không quá 500 ký tự")]
    public string? Note { get; set; }
    
    [Required(ErrorMessage = "Phương thức thanh toán là bắt buộc")]
    public PaymentMethod PaymentMethod { get; set; }
}
