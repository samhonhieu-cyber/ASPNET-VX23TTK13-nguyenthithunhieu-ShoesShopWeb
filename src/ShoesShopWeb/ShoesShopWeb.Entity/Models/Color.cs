using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.Entity.Models;

public class Color
{
    [Key]
    public int ColorId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string ColorName { get; set; } = string.Empty;
    
    [MaxLength(7)]
    public string? ColorCode { get; set; } // Hex color code
    
    public bool IsActive { get; set; } = true;
    
    // Navigation properties
    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
}
