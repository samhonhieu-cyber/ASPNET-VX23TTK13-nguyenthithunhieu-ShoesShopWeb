using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.Pages.Staff;

[Authorize(Roles = "Staff,Admin")]
public class CategoriesModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CategoriesModel> _logger;

    public CategoriesModel(IUnitOfWork unitOfWork, ILogger<CategoriesModel> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public IEnumerable<Category> Categories { get; set; } = new List<Category>();

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            Categories = await _unitOfWork.Categories.GetAllAsync();
            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading categories");
            return Page();
        }
    }

    public async Task<IActionResult> OnGetGetCategoryAsync(int id)
    {
        try
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return new JsonResult(new
            {
                categoryId = category.CategoryId,
                categoryName = category.CategoryName,
                description = category.Description,
                isActive = category.IsActive
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting category {id}");
            return BadRequest();
        }
    }

    public async Task<IActionResult> OnPostCreateAsync(
        string categoryName,
        string? description,
        bool isActive = true)
    {
        try
        {
            var category = new Category
            {
                CategoryName = categoryName,
                Description = description,
                IsActive = isActive,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Thêm danh mục thành công!";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating category");
            return BadRequest("Lỗi khi thêm danh mục");
        }
    }

    public async Task<IActionResult> OnPostUpdateAsync(
        int categoryId,
        string categoryName,
        string? description,
        bool isActive = true)
    {
        try
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            category.CategoryName = categoryName;
            category.Description = description;
            category.IsActive = isActive;
            category.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Cập nhật danh mục thành công!";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error updating category {categoryId}");
            return BadRequest("Lỗi khi cập nhật danh mục");
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        try
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Check if category has products
            var products = await _unitOfWork.Products.FindAsync(p => p.CategoryId == id);
            if (products.Any())
            {
                return BadRequest("Không thể xóa danh mục có sản phẩm");
            }

            _unitOfWork.Categories.Delete(category);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Xóa danh mục thành công!";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error deleting category {id}");
            return BadRequest("Lỗi khi xóa danh mục");
        }
    }
}
