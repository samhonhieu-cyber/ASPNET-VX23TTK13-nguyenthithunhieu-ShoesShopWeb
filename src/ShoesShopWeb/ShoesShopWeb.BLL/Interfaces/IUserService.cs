using ShoesShopWeb.Entity.DTOs;

namespace ShoesShopWeb.BLL.Interfaces;

public interface IUserService
{
    Task<(bool Success, string Message, UserDto? User)> RegisterAsync(UserRegisterDto registerDto);
    Task<(bool Success, string Message, UserDto? User)> LoginAsync(UserLoginDto loginDto);
    Task<UserDto?> GetUserByIdAsync(int userId);
    Task<UserDto?> GetUserByEmailAsync(string email);
    Task<bool> UpdateProfileAsync(int userId, UserUpdateDto updateDto);
    Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
    Task<bool> DeactivateUserAsync(int userId);
    Task<bool> EmailExistsAsync(string email);
}
