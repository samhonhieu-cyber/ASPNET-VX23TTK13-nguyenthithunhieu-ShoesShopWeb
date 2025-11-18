using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Interfaces;

public interface IColorRepository : IRepository<Color>
{
    Task<IEnumerable<Color>> GetActiveColorsAsync();
}
