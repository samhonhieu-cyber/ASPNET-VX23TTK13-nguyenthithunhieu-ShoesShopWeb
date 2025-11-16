using ShoesShopWeb.BLL.Helpers;
using ShoesShopWeb.BLL.Interfaces;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.DTOs;
using ShoesShopWeb.Entity.Enums;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.BLL.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<(bool Success, string Message, UserDto? User)> RegisterAsync(UserRegisterDto registerDto)
    {
        try
        {
            // Check if email already exists
            if (await _unitOfWork.Users.EmailExistsAsync(registerDto.Email))
            {
                return (false, "Email đã được sử dụng", null);
            }

            // Create new user
            var user = new User
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                Address = registerDto.Address,
                PasswordHash = PasswordHasher.HashPassword(registerDto.Password),
                Role = UserRole.Customer,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Users.AddAsync(user);
            
            // Create cart for new user
            var cart = new Cart
            {
                UserId = user.UserId,
                CreatedAt = DateTime.UtcNow
            };
            await _unitOfWork.Carts.AddAsync(cart);
            
            await _unitOfWork.SaveChangesAsync();

            var userDto = MapToUserDto(user);
            return (true, "Đăng ký thành công", userDto);
        }
        catch (Exception ex)
        {
            return (false, $"Lỗi: {ex.Message}", null);
        }
    }

    public async Task<(bool Success, string Message, UserDto? User)> LoginAsync(UserLoginDto loginDto)
    {
        try
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(loginDto.Email);
            
            if (user == null)
            {
                return (false, "Email hoặc mật khẩu không đúng", null);
            }

            if (!user.IsActive)
            {
                return (false, "Tài khoản đã bị khóa", null);
            }

            if (!PasswordHasher.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return (false, "Email hoặc mật khẩu không đúng", null);
            }

            var userDto = MapToUserDto(user);
            return (true, "Đăng nhập thành công", userDto);
        }
        catch (Exception ex)
        {
            return (false, $"Lỗi: {ex.Message}", null);
        }
    }

    public async Task<UserDto?> GetUserByIdAsync(int userId)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        return user != null ? MapToUserDto(user) : null;
    }

    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(email);
        return user != null ? MapToUserDto(user) : null;
    }

    public async Task<bool> UpdateProfileAsync(int userId, UserUpdateDto updateDto)
    {
        try
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null) return false;

            user.FullName = updateDto.FullName;
            user.PhoneNumber = updateDto.PhoneNumber;
            user.Address = updateDto.Address;
            user.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
    {
        try
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null) return false;

            if (!PasswordHasher.VerifyPassword(oldPassword, user.PasswordHash))
            {
                return false;
            }

            user.PasswordHash = PasswordHasher.HashPassword(newPassword);
            user.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeactivateUserAsync(int userId)
    {
        try
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null) return false;

            user.IsActive = false;
            user.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _unitOfWork.Users.EmailExistsAsync(email);
    }

    private static UserDto MapToUserDto(User user)
    {
        return new UserDto
        {
            UserId = user.UserId,
            FullName = user.FullName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address,
            Role = user.Role.ToString(),
            IsActive = user.IsActive
        };
    }
}
