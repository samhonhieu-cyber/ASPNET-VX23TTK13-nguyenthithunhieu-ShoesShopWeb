using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.BLL.Interfaces;

public interface ISizeService
{
    Task<List<Size>> GetAllSizesAsync();
    Task<List<Size>> GetActiveSizesAsync();
    Task<Size?> GetSizeByIdAsync(int sizeId);
}
