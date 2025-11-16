using Microsoft.EntityFrameworkCore;
using ShoesShopWeb.DAL.Data;
using ShoesShopWeb.DAL.Interfaces;
using ShoesShopWeb.Entity.Models;
using ShoesShopWeb.Entity.Enums;

namespace ShoesShopWeb.DAL.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
    {
        return await _dbSet
            .Where(o => o.UserId == userId)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.ProductVariant)
                    .ThenInclude(pv => pv.Product)
            .Include(o => o.Payment)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderWithDetailsAsync(int orderId)
    {
        return await _dbSet
            .Include(o => o.User)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.ProductVariant)
                    .ThenInclude(pv => pv.Product)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.ProductVariant)
                    .ThenInclude(pv => pv.Color)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.ProductVariant)
                    .ThenInclude(pv => pv.Size)
            .Include(o => o.Payment)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);
    }

    public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        return await _dbSet
            .Where(o => o.Status == status)
            .Include(o => o.User)
            .Include(o => o.OrderItems)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetRecentOrdersAsync(int count)
    {
        return await _dbSet
            .Include(o => o.User)
            .Include(o => o.OrderItems)
            .OrderByDescending(o => o.OrderDate)
            .Take(count)
            .ToListAsync();
    }
}
