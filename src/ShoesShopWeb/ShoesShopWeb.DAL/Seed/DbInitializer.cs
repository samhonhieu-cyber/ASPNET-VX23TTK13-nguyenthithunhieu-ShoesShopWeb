using System.Security.Cryptography;
using System.Text;
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
    }
}
