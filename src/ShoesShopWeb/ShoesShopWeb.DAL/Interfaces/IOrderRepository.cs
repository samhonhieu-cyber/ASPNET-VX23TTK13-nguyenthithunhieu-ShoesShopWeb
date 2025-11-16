using ShoesShopWeb.Entity.Models;
using ShoesShopWeb.Entity.Enums;

namespace ShoesShopWeb.DAL.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
    Task<Order?> GetOrderWithDetailsAsync(int orderId);
    Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
    Task<IEnumerable<Order>> GetRecentOrdersAsync(int count);
}
