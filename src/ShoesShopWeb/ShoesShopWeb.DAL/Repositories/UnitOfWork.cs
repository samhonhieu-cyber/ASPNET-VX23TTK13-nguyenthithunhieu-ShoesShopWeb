using Microsoft.EntityFrameworkCore.Storage;
using ShoesShopWeb.DAL.Data;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;

namespace ShoesShopWeb.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        
        // Initialize repositories
        Users = new UserRepository(_context);
        Products = new ProductRepository(_context);
        Categories = new CategoryRepository(_context);
        Orders = new OrderRepository(_context);
        Carts = new Repository<Cart>(_context);
        CartItems = new Repository<CartItem>(_context);
        OrderItems = new Repository<OrderItem>(_context);
        Payments = new Repository<Payment>(_context);
        ProductVariants = new Repository<ProductVariant>(_context);
        Colors = new Repository<Color>(_context);
        Sizes = new Repository<Size>(_context);
    }

    public IUserRepository Users { get; private set; }
    public IProductRepository Products { get; private set; }
    public ICategoryRepository Categories { get; private set; }
    public IOrderRepository Orders { get; private set; }
    public IRepository<Cart> Carts { get; private set; }
    public IRepository<CartItem> CartItems { get; private set; }
    public IRepository<OrderItem> OrderItems { get; private set; }
    public IRepository<Payment> Payments { get; private set; }
    public IRepository<ProductVariant> ProductVariants { get; private set; }
    public IRepository<Color> Colors { get; private set; }
    public IRepository<Size> Sizes { get; private set; }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
