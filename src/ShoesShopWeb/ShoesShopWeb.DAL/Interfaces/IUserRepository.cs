using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> EmailExistsAsync(string email);
    Task<User?> GetUserWithCartAsync(int userId);
    Task<User?> GetUserWithOrdersAsync(int userId);
}
