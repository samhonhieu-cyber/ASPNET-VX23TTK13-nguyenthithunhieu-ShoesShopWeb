using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesShopWeb.Entity.Models;

public class ProductVariant
{
    [Key]
    public int VariantId { get; set; }
    
    [Required]
    public int ProductId { get; set; }
    
    [Required]
    public int ColorId { get; set; }
    
    [Required]
    public int SizeId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    [Required]
    public int StockQuantity { get; set; }
    
    [MaxLength(20)]
    public string? SKU { get; set; } // Stock Keeping Unit
    
    public bool IsActive { get; set; } = true;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;
    
    [ForeignKey(nameof(ColorId))]
    public virtual Color Color { get; set; } = null!;
    
    [ForeignKey(nameof(SizeId))]
    public virtual Size Size { get; set; } = null!;
    
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
