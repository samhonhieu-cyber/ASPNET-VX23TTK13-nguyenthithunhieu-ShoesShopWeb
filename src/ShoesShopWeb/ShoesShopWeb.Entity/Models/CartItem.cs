using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesShopWeb.Entity.Models;

public class CartItem
{
    [Key]
    public int CartItemId { get; set; }
    
    [Required]
    public int CartId { get; set; }
    
    [Required]
    public int VariantId { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    [ForeignKey(nameof(CartId))]
    public virtual Cart Cart { get; set; } = null!;
    
    [ForeignKey(nameof(VariantId))]
    public virtual ProductVariant ProductVariant { get; set; } = null!;
}
