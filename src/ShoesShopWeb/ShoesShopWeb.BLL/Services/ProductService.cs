using ShoesShopWeb.BLL.Interfaces;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.DTOs;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.BLL.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        return products.Select(MapToProductDto);
    }

    public async Task<IEnumerable<ProductDto>> GetActiveProductsAsync()
    {
        var products = await _unitOfWork.Products.GetActiveProductsAsync();
        return products.Select(MapToProductDto);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(int categoryId)
    {
        var products = await _unitOfWork.Products.GetProductsByCategoryAsync(categoryId);
        return products.Select(MapToProductDto);
    }

    public async Task<ProductDto?> GetProductByIdAsync(int productId)
    {
        var product = await _unitOfWork.Products.GetProductWithVariantsAsync(productId);
        return product != null ? MapToProductDto(product) : null;
    }

    public async Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm)
    {
        var products = await _unitOfWork.Products.SearchProductsAsync(searchTerm);
        return products.Select(MapToProductDto);
    }

    public async Task<(bool Success, string Message, int? ProductId)> CreateProductAsync(ProductCreateDto createDto)
    {
        try
        {
            // Validate category exists
            if (!await _unitOfWork.Categories.AnyAsync(c => c.CategoryId == createDto.CategoryId))
            {
                return (false, "Danh mục không tồn tại", null);
            }

            var product = new Product
            {
                ProductName = createDto.ProductName,
                Description = createDto.Description,
                BasePrice = createDto.BasePrice,
                CategoryId = createDto.CategoryId,
                ImageUrl = createDto.ImageUrl,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Tạo sản phẩm thành công", product.ProductId);
        }
        catch (Exception ex)
        {
            return (false, $"Lỗi: {ex.Message}", null);
        }
    }

    public async Task<(bool Success, string Message)> UpdateProductAsync(int productId, ProductUpdateDto updateDto)
    {
        try
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
            {
                return (false, "Sản phẩm không tồn tại");
            }

            // Validate category exists
            if (!await _unitOfWork.Categories.AnyAsync(c => c.CategoryId == updateDto.CategoryId))
            {
                return (false, "Danh mục không tồn tại");
            }

            product.ProductName = updateDto.ProductName;
            product.Description = updateDto.Description;
            product.BasePrice = updateDto.BasePrice;
            product.CategoryId = updateDto.CategoryId;
            product.ImageUrl = updateDto.ImageUrl;
            product.IsActive = updateDto.IsActive;
            product.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Cập nhật sản phẩm thành công");
        }
        catch (Exception ex)
        {
            return (false, $"Lỗi: {ex.Message}");
        }
    }

    public async Task<(bool Success, string Message)> DeleteProductAsync(int productId)
    {
        try
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
            {
                return (false, "Sản phẩm không tồn tại");
            }

            // Soft delete
            product.IsActive = false;
            product.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return (true, "Xóa sản phẩm thành công");
        }
        catch (Exception ex)
        {
            return (false, $"Lỗi: {ex.Message}");
        }
    }

    public async Task<bool> ProductExistsAsync(int productId)
    {
        return await _unitOfWork.Products.AnyAsync(p => p.ProductId == productId);
    }

    public async Task<List<Product>> GetFeaturedProductsAsync(int count)
    {
        var products = await _unitOfWork.Products.GetActiveProductsAsync();
        return products.Take(count).ToList();
    }

    public async Task<(List<Product> Products, int TotalCount)> GetProductsWithFiltersAsync(
        string? keyword,
        int? categoryId,
        List<int>? sizeIds,
        List<int>? colorIds,
        decimal? minPrice,
        decimal? maxPrice,
        string? sortBy,
        int pageNumber,
        int pageSize)
    {
        var products = (await _unitOfWork.Products.GetActiveProductsAsync()).AsQueryable();
        
        // Apply filters
        if (!string.IsNullOrEmpty(keyword))
        {
            products = products.Where(p => 
                p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                (p.Description != null && p.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            );
        }

        if (categoryId.HasValue)
        {
            products = products.Where(p => p.CategoryId == categoryId.Value);
        }

        if (minPrice.HasValue)
        {
            products = products.Where(p => p.BasePrice >= minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            products = products.Where(p => p.BasePrice <= maxPrice.Value);
        }

        // Sort
        products = sortBy switch
        {
            "name" => products.OrderBy(p => p.ProductName),
            "price-asc" => products.OrderBy(p => p.BasePrice),
            "price-desc" => products.OrderByDescending(p => p.BasePrice),
            "newest" => products.OrderByDescending(p => p.CreatedAt),
            _ => products.OrderBy(p => p.ProductId)
        };

        var totalCount = products.Count();

        // Pagination
        var result = products
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return (result, totalCount);
    }

    public async Task<Product?> GetProductWithDetailsAsync(int productId)
    {
        return await _unitOfWork.Products.GetProductWithVariantsAsync(productId);
    }

    private static ProductDto MapToProductDto(Product product)
    {
        return new ProductDto
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            Description = product.Description,
            BasePrice = product.BasePrice,
            CategoryId = product.CategoryId,
            CategoryName = product.Category?.CategoryName ?? string.Empty,
            ImageUrl = product.ImageUrl,
            IsActive = product.IsActive,
            CreatedAt = product.CreatedAt
        };
    }
}
