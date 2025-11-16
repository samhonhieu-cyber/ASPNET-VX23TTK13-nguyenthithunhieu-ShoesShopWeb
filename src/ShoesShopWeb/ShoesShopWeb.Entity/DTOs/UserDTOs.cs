using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.Entity.DTOs;

public class UserRegisterDto
{
    [Required(ErrorMessage = "Họ tên không được để trống")]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    [MaxLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
    [MaxLength(100)]
    public string Password { get; set; } = string.Empty;
    
    [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
    public string ConfirmPassword { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Address { get; set; }
}

public class UserLoginDto
{
    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    public string Password { get; set; } = string.Empty;
}

public class UserDto
{
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string Role { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class UserUpdateDto
{
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;
    
    [Required]
    [Phone]
    [MaxLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Address { get; set; }
}
