using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShoesShopWeb.Entity.Enums;

namespace ShoesShopWeb.Entity.Models;

public class Payment
{
    [Key]
    public int PaymentId { get; set; }
    
    [Required]
    public int OrderId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    
    [Required]
    public PaymentMethod PaymentMethod { get; set; }
    
    [Required]
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    
    [MaxLength(100)]
    public string? TransactionId { get; set; }
    
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(OrderId))]
    public virtual Order Order { get; set; } = null!;
}
