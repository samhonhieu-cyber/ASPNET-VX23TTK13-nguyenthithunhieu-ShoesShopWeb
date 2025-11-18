using ShoesShopWeb.Entity.DTOs;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.BLL.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<IEnumerable<CategoryDto>> GetActiveCategoriesAsync();
    Task<CategoryDto?> GetCategoryByIdAsync(int categoryId);
    Task<(bool Success, string Message, int? CategoryId)> CreateCategoryAsync(CategoryCreateDto createDto);
    Task<(bool Success, string Message)> UpdateCategoryAsync(int categoryId, CategoryUpdateDto updateDto);
    Task<(bool Success, string Message)> DeleteCategoryAsync(int categoryId);
    Task<bool> CategoryExistsAsync(int categoryId);
    Task<List<Category>> GetAllActiveCategoriesAsync();
}
