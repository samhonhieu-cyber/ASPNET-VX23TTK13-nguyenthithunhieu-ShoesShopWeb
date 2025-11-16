using Microsoft.EntityFrameworkCore;
using ShoesShopWeb.DAL.Data;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _dbSet.AnyAsync(u => u.Email == email);
    }

    public async Task<User?> GetUserWithCartAsync(int userId)
    {
        return await _dbSet
            .Include(u => u.Cart)
                .ThenInclude(c => c.CartItems)
                    .ThenInclude(ci => ci.ProductVariant)
                        .ThenInclude(pv => pv.Product)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task<User?> GetUserWithOrdersAsync(int userId)
    {
        return await _dbSet
            .Include(u => u.Orders)
                .ThenInclude(o => o.OrderItems)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }
}
