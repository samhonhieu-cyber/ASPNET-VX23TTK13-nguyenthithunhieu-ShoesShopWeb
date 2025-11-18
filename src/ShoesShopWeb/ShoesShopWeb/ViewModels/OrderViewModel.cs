using System.ComponentModel.DataAnnotations;
using ShoesShopWeb.Entity.Enums;

namespace ShoesShopWeb.ViewModels;

public class OrderViewModel
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public string ShippingAddress { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Note { get; set; }
    public List<OrderItemViewModel> Items { get; set; } = new();
}

public class OrderItemViewModel
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int VariantId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    
    // Product details
    public string ProductName { get; set; } = string.Empty;
    public string? ProductImage { get; set; }
    public string SizeValue { get; set; } = string.Empty;
    public string ColorName { get; set; } = string.Empty;
}

public class CheckoutViewModel
{
    [Required(ErrorMessage = "Họ tên là bắt buộc")]
    [Display(Name = "Họ tên")]
    public string FullName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
    [Display(Name = "Số điện thoại")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Địa chỉ giao hàng là bắt buộc")]
    [StringLength(500)]
    [Display(Name = "Địa chỉ giao hàng")]
    public string ShippingAddress { get; set; } = string.Empty;
    
    [StringLength(500)]
    [Display(Name = "Ghi chú")]
    public string? Note { get; set; }
    
    public CartViewModel Cart { get; set; } = new();
}
