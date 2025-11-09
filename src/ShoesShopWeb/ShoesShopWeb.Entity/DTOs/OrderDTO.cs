using ShoesShopWeb.Entity.Enums;

namespace ShoesShopWeb.Entity.DTOs;

public class OrderDTO
{
    public int OrderId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public int UserId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public string ShippingAddress { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Note { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
    public PaymentDTO? Payment { get; set; }
}
