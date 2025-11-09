using ShoesShopWeb.Entity.Enums;

namespace ShoesShopWeb.Entity.DTOs;

public class PaymentDTO
{
    public int PaymentId { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus Status { get; set; }
    public string? TransactionId { get; set; }
    public DateTime PaymentDate { get; set; }
}
