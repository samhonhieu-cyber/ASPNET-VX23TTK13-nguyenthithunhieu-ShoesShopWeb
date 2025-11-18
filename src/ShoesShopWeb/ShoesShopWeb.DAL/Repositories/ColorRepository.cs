using Microsoft.EntityFrameworkCore;
using ShoesShopWeb.DAL.Data;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Repositories;

public class ColorRepository : Repository<Color>, IColorRepository
{
    public ColorRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Color>> GetActiveColorsAsync()
    {
        return await _dbSet
            .Where(c => c.IsActive)
            .OrderBy(c => c.ColorName)
            .ToListAsync();
    }
}
