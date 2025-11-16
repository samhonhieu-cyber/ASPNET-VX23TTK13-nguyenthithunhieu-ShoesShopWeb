using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShoesShopWeb.DAL.Data;
using ShoesShopWeb.Entity.Enums;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Seed;

public static class DbInitializer
{
    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }

    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Ensure database is created
        await context.Database.EnsureCreatedAsync();

        // Seed Categories
        if (!context.Categories.Any())
        {
            var categories = new[]
            {
                new Category { CategoryName = "Giày Thể Thao", Description = "Giày dành cho hoạt động thể thao", IsActive = true, CreatedAt = DateTime.UtcNow },
                new Category { CategoryName = "Giày Công Sở", Description = "Giày lịch sự cho văn phòng", IsActive = true, CreatedAt = DateTime.UtcNow },
                new Category { CategoryName = "Giày Sneaker", Description = "Giày sneaker thời trang", IsActive = true, CreatedAt = DateTime.UtcNow },
                new Category { CategoryName = "Giày Sandal", Description = "Dép và sandal", IsActive = true, CreatedAt = DateTime.UtcNow },
                new Category { CategoryName = "Giày Boot", Description = "Giày boot các loại", IsActive = true, CreatedAt = DateTime.UtcNow }
            };
            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }

        // Seed Colors
        if (!context.Colors.Any())
        {
            var colors = new[]
            {
                new Color { ColorName = "Đen", ColorCode = "#000000", IsActive = true },
                new Color { ColorName = "Trắng", ColorCode = "#FFFFFF", IsActive = true },
                new Color { ColorName = "Đỏ", ColorCode = "#FF0000", IsActive = true },
                new Color { ColorName = "Xanh Navy", ColorCode = "#000080", IsActive = true },
                new Color { ColorName = "Xám", ColorCode = "#808080", IsActive = true },
                new Color { ColorName = "Nâu", ColorCode = "#8B4513", IsActive = true },
                new Color { ColorName = "Xanh Lá", ColorCode = "#008000", IsActive = true }
            };
            await context.Colors.AddRangeAsync(colors);
            await context.SaveChangesAsync();
        }

        // Seed Sizes
        if (!context.Sizes.Any())
        {
            var sizes = new[]
            {
                new Size { SizeValue = "36", IsActive = true },
                new Size { SizeValue = "37", IsActive = true },
                new Size { SizeValue = "38", IsActive = true },
                new Size { SizeValue = "39", IsActive = true },
                new Size { SizeValue = "40", IsActive = true },
                new Size { SizeValue = "41", IsActive = true },
                new Size { SizeValue = "42", IsActive = true },
                new Size { SizeValue = "43", IsActive = true },
                new Size { SizeValue = "44", IsActive = true }
            };
            await context.Sizes.AddRangeAsync(sizes);
            await context.SaveChangesAsync();
        }

        // Seed Admin User
        if (!context.Users.Any())
        {
            var adminUser = new User
            {
                FullName = "Administrator",
                Email = "admin@shoesshop.com",
                PhoneNumber = "0123456789",
                PasswordHash = HashPassword("Admin@123"),
                Address = "Hà Nội, Việt Nam",
                Role = UserRole.Admin,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };
            await context.Users.AddAsync(adminUser);
            await context.SaveChangesAsync();

            // Create cart for admin
            var adminCart = new Cart
            {
                UserId = adminUser.UserId,
                CreatedAt = DateTime.UtcNow
            };
            await context.Carts.AddAsync(adminCart);
            await context.SaveChangesAsync();
        }

        // Seed Products
        if (!context.Products.Any())
        {
            var categories = await context.Categories.ToListAsync();
            var colors = await context.Colors.ToListAsync();
            var sizes = await context.Sizes.ToListAsync();

            if (categories.Any() && colors.Any() && sizes.Any())
            {
                var products = new[]
                {
                    new Product
                    {
                        ProductName = "Nike Air Max 2024",
                        Description = "Giày thể thao Nike Air Max với thiết kế hiện đại và công nghệ đệm khí tiên tiến",
                        BasePrice = 2500000m,
                        CategoryId = categories.First(c => c.CategoryName == "Giày Thể Thao").CategoryId,
                        ImageUrl = "/images/products/nike-air-max.jpg",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        ProductName = "Adidas Ultraboost 22",
                        Description = "Giày chạy bộ Adidas Ultraboost với công nghệ Boost độc quyền",
                        BasePrice = 2800000m,
                        CategoryId = categories.First(c => c.CategoryName == "Giày Thể Thao").CategoryId,
                        ImageUrl = "/images/products/adidas-ultraboost.jpg",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        ProductName = "Converse Chuck Taylor All Star",
                        Description = "Giày sneaker cổ điển Converse Chuck Taylor với thiết kế vượt thời gian",
                        BasePrice = 1200000m,
                        CategoryId = categories.First(c => c.CategoryName == "Giày Sneaker").CategoryId,
                        ImageUrl = "/images/products/converse-chuck-taylor.jpg",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        ProductName = "Clarks Oxford Leather",
                        Description = "Giày công sở da thật Clarks Oxford sang trọng và lịch sự",
                        BasePrice = 3500000m,
                        CategoryId = categories.First(c => c.CategoryName == "Giày Công Sở").CategoryId,
                        ImageUrl = "/images/products/clarks-oxford.jpg",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        ProductName = "Timberland 6-Inch Boot",
                        Description = "Giày boot Timberland chống nước cao cấp",
                        BasePrice = 4000000m,
                        CategoryId = categories.First(c => c.CategoryName == "Giày Boot").CategoryId,
                        ImageUrl = "/images/products/timberland-boot.jpg",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();

                // Seed Product Variants
                var productsList = await context.Products.ToListAsync();
                var variants = new List<ProductVariant>();
                var random = new Random();

                foreach (var product in productsList)
                {
                    // Tạo variants cho mỗi sản phẩm với 2-3 màu và nhiều size
                    var productColors = colors.Take(3).ToList();
                    var productSizes = sizes.Take(6).ToList(); // Size 36-41

                    foreach (var color in productColors)
                    {
                        foreach (var size in productSizes)
                        {
                            // Tính giá variant dựa trên BasePrice với biến động nhỏ
                            var variantPrice = product.BasePrice + (decimal)(random.Next(-100000, 200000));
                            
                            variants.Add(new ProductVariant
                            {
                                ProductId = product.ProductId,
                                ColorId = color.ColorId,
                                SizeId = size.SizeId,
                                SKU = $"PRD{product.ProductId}-CLR{color.ColorId}-SZ{size.SizeId}",
                                Price = variantPrice > 0 ? variantPrice : product.BasePrice,
                                StockQuantity = random.Next(5, 50),
                                IsActive = true,
                                CreatedAt = DateTime.UtcNow
                            });
                        }
                    }
                }

                await context.ProductVariants.AddRangeAsync(variants);
                await context.SaveChangesAsync();
            }
        }
    }
}
