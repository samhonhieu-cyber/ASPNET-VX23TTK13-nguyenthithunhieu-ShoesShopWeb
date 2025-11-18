using ShoesShopWeb.BLL.Interfaces;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.BLL.Services;

public class ColorService : IColorService
{
    private readonly IUnitOfWork _unitOfWork;

    public ColorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Color>> GetAllColorsAsync()
    {
        var colors = await _unitOfWork.Colors.GetAllAsync();
        return colors.ToList();
    }

    public async Task<List<Color>> GetActiveColorsAsync()
    {
        var colors = await _unitOfWork.Colors.GetActiveColorsAsync();
        return colors.ToList();
    }

    public async Task<Color?> GetColorByIdAsync(int colorId)
    {
        return await _unitOfWork.Colors.GetByIdAsync(colorId);
    }
}
