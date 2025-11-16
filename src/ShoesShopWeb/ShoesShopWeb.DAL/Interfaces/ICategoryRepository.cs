using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetCategoryWithProductsAsync(int categoryId);
    Task<IEnumerable<Category>> GetActiveCategoriesAsync();
}
