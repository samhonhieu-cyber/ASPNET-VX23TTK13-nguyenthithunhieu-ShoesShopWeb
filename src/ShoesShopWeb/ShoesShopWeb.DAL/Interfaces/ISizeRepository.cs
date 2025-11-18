using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Interfaces;

public interface ISizeRepository : IRepository<Size>
{
    Task<IEnumerable<Size>> GetActiveSizesAsync();
}
