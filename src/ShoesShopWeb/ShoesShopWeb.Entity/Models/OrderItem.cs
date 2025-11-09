using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesShopWeb.Entity.Models;

public class OrderItem
{
    [Key]
    public int OrderItemId { get; set; }
    
    [Required]
    public int OrderId { get; set; }
    
    [Required]
    public int VariantId { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Subtotal { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(OrderId))]
    public virtual Order Order { get; set; } = null!;
    
    [ForeignKey(nameof(VariantId))]
    public virtual ProductVariant ProductVariant { get; set; } = null!;
}
