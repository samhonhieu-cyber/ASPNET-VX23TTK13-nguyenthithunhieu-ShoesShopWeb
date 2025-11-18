using ShoesShopWeb.BLL.Interfaces;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.DTOs;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        return categories.Select(MapToCategoryDto);
    }

    public async Task<IEnumerable<CategoryDto>> GetActiveCategoriesAsync()
    {
        var categories = await _unitOfWork.Categories.GetActiveCategoriesAsync();
        return categories.Select(MapToCategoryDto);
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(int categoryId)
    {
        var category = await _unitOfWork.Categories.GetCategoryWithProductsAsync(categoryId);
        return category != null ? MapToCategoryDto(category) : null;
    }

    public async Task<(bool Success, string Message, int? CategoryId)> CreateCategoryAsync(CategoryCreateDto createDto)
    {
        try
        {
            var category = new Category
            {
                CategoryName = createDto.CategoryName,
                Description = createDto.Description,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Tạo danh mục thành công", category.CategoryId);
        }
        catch (Exception ex)
        {
            return (false, $"Lỗi: {ex.Message}", null);
        }
    }

    public async Task<(bool Success, string Message)> UpdateCategoryAsync(int categoryId, CategoryUpdateDto updateDto)
    {
        try
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(categoryId);
            if (category == null)
            {
                return (false, "Danh mục không tồn tại");
            }

            category.CategoryName = updateDto.CategoryName;
            category.Description = updateDto.Description;
            category.IsActive = updateDto.IsActive;
            category.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Cập nhật danh mục thành công");
        }
        catch (Exception ex)
        {
            return (false, $"Lỗi: {ex.Message}");
        }
    }

    public async Task<(bool Success, string Message)> DeleteCategoryAsync(int categoryId)
    {
        try
        {
            var category = await _unitOfWork.Categories.GetCategoryWithProductsAsync(categoryId);
            if (category == null)
            {
                return (false, "Danh mục không tồn tại");
            }

            // Check if category has products
            if (category.Products.Any())
            {
                return (false, "Không thể xóa danh mục có sản phẩm");
            }

            // Soft delete
            category.IsActive = false;
            category.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Xóa danh mục thành công");
        }
        catch (Exception ex)
        {
            return (false, $"Lỗi: {ex.Message}");
        }
    }

    public async Task<bool> CategoryExistsAsync(int categoryId)
    {
        return await _unitOfWork.Categories.AnyAsync(c => c.CategoryId == categoryId);
    }

    public async Task<List<Category>> GetAllActiveCategoriesAsync()
    {
        var categories = await _unitOfWork.Categories.GetActiveCategoriesAsync();
        return categories.ToList();
    }

    private static CategoryDto MapToCategoryDto(Category category)
    {
        return new CategoryDto
        {
            CategoryId = category.CategoryId,
            CategoryName = category.CategoryName,
            Description = category.Description,
            IsActive = category.IsActive,
            ProductCount = category.Products?.Count ?? 0
        };
    }
}
