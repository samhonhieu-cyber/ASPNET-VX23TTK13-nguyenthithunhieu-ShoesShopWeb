using Microsoft.EntityFrameworkCore;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    // DbSets
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // User Configuration
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Address).HasMaxLength(500);
            
            entity.HasOne(e => e.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasMany(e => e.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        // Category Configuration
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId);
            entity.Property(e => e.CategoryName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            
            entity.HasMany(e => e.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        // Product Configuration
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId);
            entity.Property(e => e.ProductName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.BasePrice).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            
            entity.HasMany(e => e.ProductVariants)
                .WithOne(pv => pv.Product)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        // Color Configuration
        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId);
            entity.Property(e => e.ColorName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ColorCode).HasMaxLength(7);
            
            entity.HasMany(e => e.ProductVariants)
                .WithOne(pv => pv.Color)
                .HasForeignKey(pv => pv.ColorId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        // Size Configuration
        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId);
            entity.Property(e => e.SizeValue).IsRequired().HasMaxLength(10);
            
            entity.HasMany(e => e.ProductVariants)
                .WithOne(pv => pv.Size)
                .HasForeignKey(pv => pv.SizeId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        // ProductVariant Configuration
        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.HasKey(e => e.VariantId);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(e => e.StockQuantity).IsRequired();
            
            entity.HasMany(e => e.CartItems)
                .WithOne(ci => ci.ProductVariant)
                .HasForeignKey(ci => ci.VariantId)
                .OnDelete(DeleteBehavior.Restrict);
                
            entity.HasMany(e => e.OrderItems)
                .WithOne(oi => oi.ProductVariant)
                .HasForeignKey(oi => oi.VariantId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        // Cart Configuration
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId);
            
            entity.HasMany(e => e.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        // CartItem Configuration
        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId);
            entity.Property(e => e.Quantity).IsRequired();
        });
        
        // Order Configuration
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(e => e.ShippingAddress).HasMaxLength(500);
            
            entity.HasMany(e => e.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasOne(e => e.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        // OrderItem Configuration
        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId);
            entity.Property(e => e.Quantity).IsRequired();
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18,2)").IsRequired();
        });
        
        // Payment Configuration
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId);
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
        });
    }
}
