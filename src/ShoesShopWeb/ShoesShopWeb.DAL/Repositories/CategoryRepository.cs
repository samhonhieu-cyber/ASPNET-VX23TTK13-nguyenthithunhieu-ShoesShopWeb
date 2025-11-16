using Microsoft.EntityFrameworkCore;
using ShoesShopWeb.DAL.Data;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetCategoryWithProductsAsync(int categoryId)
    {
        return await _dbSet
            .Include(c => c.Products.Where(p => p.IsActive))
            .FirstOrDefaultAsync(c => c.CategoryId == categoryId);
    }

    public async Task<IEnumerable<Category>> GetActiveCategoriesAsync()
    {
        return await _dbSet
            .Where(c => c.IsActive)
            .Include(c => c.Products.Where(p => p.IsActive))
            .ToListAsync();
    }
}
