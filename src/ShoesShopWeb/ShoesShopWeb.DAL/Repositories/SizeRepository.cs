using Microsoft.EntityFrameworkCore;
using ShoesShopWeb.DAL.Data;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Repositories;

public class SizeRepository : Repository<Size>, ISizeRepository
{
    public SizeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Size>> GetActiveSizesAsync()
    {
        return await _dbSet
            .Where(s => s.IsActive)
            .OrderBy(s => s.SizeValue)
            .ToListAsync();
    }
}
