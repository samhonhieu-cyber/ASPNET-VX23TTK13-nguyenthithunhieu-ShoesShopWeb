using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.Entity.DTOs;

public class RegisterDTO
{
    [Required(ErrorMessage = "Họ tên là bắt buộc")]
    [MaxLength(100, ErrorMessage = "Họ tên không quá 100 ký tự")]
    public string FullName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email là bắt buộc")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    [MaxLength(100, ErrorMessage = "Email không quá 100 ký tự")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    [MaxLength(20, ErrorMessage = "Số điện thoại không quá 20 ký tự")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
    [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
    public string Password { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Xác nhận mật khẩu là bắt buộc")]
    [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
    public string ConfirmPassword { get; set; } = string.Empty;
    
    [MaxLength(500, ErrorMessage = "Địa chỉ không quá 500 ký tự")]
    public string? Address { get; set; }
}
