namespace ShoesShopWeb.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IProductRepository Products { get; }
    ICategoryRepository Categories { get; }
    IOrderRepository Orders { get; }
    ISizeRepository Sizes { get; }
    IColorRepository Colors { get; }
    IRepository<Entity.Models.Cart> Carts { get; }
    IRepository<Entity.Models.CartItem> CartItems { get; }
    IRepository<Entity.Models.OrderItem> OrderItems { get; }
    IRepository<Entity.Models.Payment> Payments { get; }
    IRepository<Entity.Models.ProductVariant> ProductVariants { get; }
    
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
