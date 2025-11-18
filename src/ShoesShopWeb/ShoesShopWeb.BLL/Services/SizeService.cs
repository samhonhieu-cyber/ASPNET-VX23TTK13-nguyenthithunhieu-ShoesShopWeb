using ShoesShopWeb.BLL.Interfaces;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.BLL.Services;

public class SizeService : ISizeService
{
    private readonly IUnitOfWork _unitOfWork;

    public SizeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Size>> GetAllSizesAsync()
    {
        var sizes = await _unitOfWork.Sizes.GetAllAsync();
        return sizes.ToList();
    }

    public async Task<List<Size>> GetActiveSizesAsync()
    {
        var sizes = await _unitOfWork.Sizes.GetActiveSizesAsync();
        return sizes.ToList();
    }

    public async Task<Size?> GetSizeByIdAsync(int sizeId)
    {
        return await _unitOfWork.Sizes.GetByIdAsync(sizeId);
    }
}
