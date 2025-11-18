using ShoesShopWeb.Entity.DTOs;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.BLL.Interfaces;

public interface IUserService
{
    Task<(bool Success, string Message, UserDto? User)> RegisterAsync(UserRegisterDto registerDto);
    Task<(bool Success, string Message, UserDto? User)> LoginAsync(UserLoginDto loginDto);
    Task<UserDto?> GetUserByIdAsync(int userId);
    Task<UserDto?> GetUserByEmailAsync(string email);
    Task<User?> GetUserEntityByEmailAsync(string email);
    Task<bool> UpdateProfileAsync(int userId, UserUpdateDto updateDto);
    Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
    Task<bool> DeactivateUserAsync(int userId);
    Task<bool> EmailExistsAsync(string email);
    Task CreateUserAsync(User user);
    string HashPassword(string password);
    bool VerifyPassword(string password, string passwordHash);
    Task<List<User>> GetAllCustomersAsync();
    Task<bool> UpdateUserStatusAsync(int userId, bool isActive);
}
