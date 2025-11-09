using System.ComponentModel.DataAnnotations;

namespace ShoesShopWeb.Entity.Models;

public class Size
{
    [Key]
    public int SizeId { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string SizeValue { get; set; } = string.Empty; // e.g., "38", "39", "40"
    
    public bool IsActive { get; set; } = true;
    
    // Navigation properties
    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
}
