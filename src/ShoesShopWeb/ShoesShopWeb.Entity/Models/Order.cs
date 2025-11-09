using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShoesShopWeb.Entity.Enums;

namespace ShoesShopWeb.Entity.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string OrderNumber { get; set; } = string.Empty;
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    
    [Required]
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    
    [Required]
    [MaxLength(500)]
    public string ShippingAddress { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Note { get; set; }
    
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
    
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public virtual Payment? Payment { get; set; }
}
