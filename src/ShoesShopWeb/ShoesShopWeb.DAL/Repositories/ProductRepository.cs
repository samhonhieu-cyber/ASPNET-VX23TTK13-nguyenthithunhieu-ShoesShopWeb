using Microsoft.EntityFrameworkCore;
using ShoesShopWeb.DAL.Data;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        return await _dbSet
            .Where(p => p.CategoryId == categoryId && p.IsActive)
            .Include(p => p.Category)
            .Include(p => p.ProductVariants)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetActiveProductsAsync()
    {
        return await _dbSet
            .Where(p => p.IsActive)
            .Include(p => p.Category)
            .Include(p => p.ProductVariants)
            .ToListAsync();
    }

    public async Task<Product?> GetProductWithVariantsAsync(int productId)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Include(p => p.ProductVariants)
                .ThenInclude(pv => pv.Color)
            .Include(p => p.ProductVariants)
                .ThenInclude(pv => pv.Size)
            .FirstOrDefaultAsync(p => p.ProductId == productId);
    }

    public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
    {
        return await _dbSet
            .Where(p => p.IsActive && 
                   (p.ProductName.Contains(searchTerm) || 
                    p.Description != null && p.Description.Contains(searchTerm)))
            .Include(p => p.Category)
            .Include(p => p.ProductVariants)
            .ToListAsync();
    }
}
