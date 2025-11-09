using ShoesShopWeb.Entity.Enums;

namespace ShoesShopWeb.Entity.DTOs;

public class UserDTO
{
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Address { get; set; }
    public UserRole Role { get; set; }
    public bool IsActive { get; set; }
}
