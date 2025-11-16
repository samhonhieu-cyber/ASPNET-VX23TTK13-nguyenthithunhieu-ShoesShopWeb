using ShoesShopWeb.Entity.DTOs;

namespace ShoesShopWeb.BLL.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<IEnumerable<ProductDto>> GetActiveProductsAsync();
    Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId);
    Task<ProductDto?> GetProductByIdAsync(int productId);
    Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm);
    Task<(bool Success, string Message, int? ProductId)> CreateProductAsync(ProductCreateDto createDto);
    Task<(bool Success, string Message)> UpdateProductAsync(int productId, ProductUpdateDto updateDto);
    Task<(bool Success, string Message)> DeleteProductAsync(int productId);
    Task<bool> ProductExistsAsync(int productId);
}
