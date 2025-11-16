using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    Task<IEnumerable<Product>> GetActiveProductsAsync();
    Task<Product?> GetProductWithVariantsAsync(int productId);
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
}
