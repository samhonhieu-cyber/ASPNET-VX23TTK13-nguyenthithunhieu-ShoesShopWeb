using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.BLL.Interfaces;

public interface IColorService
{
    Task<List<Color>> GetAllColorsAsync();
    Task<List<Color>> GetActiveColorsAsync();
    Task<Color?> GetColorByIdAsync(int colorId);
}
