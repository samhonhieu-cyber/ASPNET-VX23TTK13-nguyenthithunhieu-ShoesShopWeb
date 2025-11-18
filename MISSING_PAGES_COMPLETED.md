# Bổ Sung Các Trang Còn Thiếu - Razor Pages

## Vấn Đề
Sau khi chuyển đổi từ MVC sang Razor Pages, các trang sau chưa được tạo:
- **Cart**: Giỏ hàng
- **Profile**: Trang cá nhân
- **Orders**: Lịch sử đơn hàng

Điều này dẫn đến:
- ❌ Không thể thêm sản phẩm vào giỏ hàng
- ❌ Không truy cập được trang giỏ hàng
- ❌ Không truy cập được trang profile
- ❌ Không xem được lịch sử đơn hàng

## Giải Pháp Đã Thực Hiện

### 1. Tạo Cart Pages (Giỏ Hàng)

#### `Pages/Cart/Index.cshtml`
- Hiển thị danh sách sản phẩm trong giỏ
- Chức năng tăng/giảm số lượng
- Chức năng xóa sản phẩm
- Tính tổng tiền
- Nút thanh toán

#### `Pages/Cart/Index.cshtml.cs`
**Handler Methods:**
- `OnGetAsync()`: Load giỏ hàng của user
- `OnPostAddToCartAsync()`: Thêm sản phẩm vào giỏ (API endpoint)
- `OnPostRemoveFromCartAsync()`: Xóa sản phẩm khỏi giỏ (API endpoint)
- `OnPostUpdateQuantityAsync()`: Cập nhật số lượng (API endpoint)
- `OnGetGetCartCountAsync()`: Lấy số lượng items trong giỏ (API endpoint)

**Logic:**
```csharp
// Tự động tạo cart nếu chưa có
if (cart == null)
{
    cart = new Entity.Models.Cart
    {
        UserId = userId,
        CreatedAt = DateTime.UtcNow
    };
    await _unitOfWork.Carts.AddAsync(cart);
    await _unitOfWork.SaveChangesAsync();
}

// Kiểm tra item đã tồn tại, nếu có thì tăng quantity
if (existingItem != null)
{
    existingItem.Quantity += request.Quantity;
    _unitOfWork.CartItems.Update(existingItem);
}
```

### 2. Cập Nhật JavaScript (customer.js)

#### Thay đổi endpoints từ MVC sang Razor Pages:

**Trước (MVC):**
```javascript
fetch('/Cart/AddToCart', {...})
fetch('/Cart/GetCartCount')
fetch('/Cart/RemoveFromCart', {...})
fetch('/Cart/UpdateQuantity', {...})
```

**Sau (Razor Pages):**
```javascript
fetch('/Cart?handler=AddToCart', {...})
fetch('/Cart?handler=GetCartCount')
fetch('/Cart?handler=RemoveFromCart', {...})
fetch('/Cart?handler=UpdateQuantity', {...})
```

**Lý do:** Razor Pages sử dụng query parameter `?handler=` để gọi các handler methods khác nhau trong cùng một PageModel.

### 3. Tạo Profile Page

#### `Pages/Account/Profile.cshtml`
- Form cập nhật thông tin cá nhân
- Hiển thị vai trò (Role)
- Hiển thị ngày tham gia
- Link đến đơn hàng
- Link đổi mật khẩu (TODO)

#### `Pages/Account/Profile.cshtml.cs`
**Handler Methods:**
- `OnGetAsync()`: Load thông tin user hiện tại
- `OnPostAsync()`: Cập nhật thông tin user

**Các trường có thể cập nhật:**
- Họ tên (FullName)
- Số điện thoại (PhoneNumber)
- Địa chỉ (Address)

**Không cho phép thay đổi:**
- Email (readonly)

### 4. Tạo Orders Pages

#### `Pages/Orders/MyOrders.cshtml`
- Hiển thị danh sách đơn hàng của user
- Sắp xếp theo thời gian (mới nhất trước)
- Badge màu theo trạng thái đơn hàng:
  - ⚠️ **Chờ xử lý** (Warning - Vàng)
  - ℹ️ **Đang xử lý** (Info - Xanh dương nhạt)
  - 📦 **Đang giao** (Primary - Xanh dương)
  - ✅ **Đã giao** (Success - Xanh lá)
  - ❌ **Đã hủy** (Danger - Đỏ)
- Link xem chi tiết đơn hàng

#### `Pages/Orders/MyOrders.cshtml.cs`
**Handler Methods:**
- `OnGetAsync()`: Load danh sách đơn hàng của user

**Logic:**
```csharp
var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(userId);
Orders = orders.OrderByDescending(o => o.OrderDate).ToList();
```

## Cấu Trúc Thư Mục Sau Khi Hoàn Thành

```
Pages/
├── Account/
│   ├── Login.cshtml + .cs
│   ├── Register.cshtml + .cs
│   ├── Logout.cshtml + .cs
│   ├── AccessDenied.cshtml + .cs
│   └── Profile.cshtml + .cs ✅ MỚI
├── Cart/
│   └── Index.cshtml + .cs ✅ MỚI
├── Orders/
│   └── MyOrders.cshtml + .cs ✅ MỚI
├── Products/
│   ├── Index.cshtml + .cs
│   └── Details.cshtml + .cs
├── Staff/
│   ├── Index.cshtml + .cs
│   └── Categories.cshtml + .cs
├── Index.cshtml + .cs
└── Shared/
    ├── _Layout.cshtml
    ├── _CustomerLayout.cshtml
    └── _StaffLayout.cshtml
```

## Routing trong Razor Pages

### Cart Pages
- `GET /Cart` → Xem giỏ hàng
- `POST /Cart?handler=AddToCart` → Thêm vào giỏ (API)
- `POST /Cart?handler=RemoveFromCart` → Xóa khỏi giỏ (API)
- `POST /Cart?handler=UpdateQuantity` → Cập nhật số lượng (API)
- `GET /Cart?handler=GetCartCount` → Lấy số items (API)

### Profile
- `GET /Account/Profile` → Xem thông tin cá nhân
- `POST /Account/Profile` → Cập nhật thông tin

### Orders
- `GET /Orders/MyOrders` → Xem danh sách đơn hàng

## Handler Methods trong Razor Pages

Razor Pages hỗ trợ nhiều handler methods trong cùng một PageModel:

```csharp
public class IndexModel : PageModel
{
    // Default GET handler
    public async Task<IActionResult> OnGetAsync() { }
    
    // Default POST handler
    public async Task<IActionResult> OnPostAsync() { }
    
    // Named handler for POST
    public async Task<IActionResult> OnPostAddToCartAsync() { }
    
    // Named handler for GET
    public async Task<IActionResult> OnGetGetCartCountAsync() { }
}
```

**Gọi từ client:**
```javascript
// Default handlers
fetch('/Cart', { method: 'GET' })
fetch('/Cart', { method: 'POST' })

// Named handlers
fetch('/Cart?handler=AddToCart', { method: 'POST' })
fetch('/Cart?handler=GetCartCount', { method: 'GET' })
```

## API Endpoints (JSON Response)

Các handler trả về JSON để sử dụng với AJAX:

```csharp
// Success response
return new JsonResult(new { 
    success = true, 
    message = "Đã thêm vào giỏ hàng" 
});

// Error response
return new JsonResult(new { 
    success = false, 
    message = "Có lỗi xảy ra" 
});

// Data response
return new JsonResult(new { 
    count = 5 
});
```

## Bảo Mật

### Authorization
Tất cả các trang yêu cầu đăng nhập:
```csharp
[Authorize]
public class IndexModel : PageModel { }
```

hoặc trong Razor:
```html
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize]
```

### Anti-Forgery Token
Tự động được thêm trong form POST:
```html
<form method="post">
    <!-- Token tự động -->
</form>
```

Cho AJAX request, cần thêm thủ công:
```javascript
headers: {
    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]')?.value
}
```

## Các Trang Cần Tạo Thêm (TODO)

### Cart
- ✅ `Pages/Cart/Index.cshtml` - Xem giỏ hàng
- ⬜ `Pages/Cart/Checkout.cshtml` - Thanh toán

### Orders
- ✅ `Pages/Orders/MyOrders.cshtml` - Danh sách đơn hàng
- ⬜ `Pages/Orders/Details.cshtml` - Chi tiết đơn hàng
- ⬜ `Pages/Orders/Track.cshtml` - Theo dõi đơn hàng

### Account
- ✅ `Pages/Account/Profile.cshtml` - Thông tin cá nhân
- ⬜ `Pages/Account/ChangePassword.cshtml` - Đổi mật khẩu

### Staff (Mở rộng)
- ⬜ `Pages/Staff/CreateCategory.cshtml` - Tạo danh mục
- ⬜ `Pages/Staff/EditCategory.cshtml` - Sửa danh mục
- ⬜ `Pages/Staff/Products.cshtml` - Quản lý sản phẩm
- ⬜ `Pages/Staff/Customers.cshtml` - Quản lý khách hàng
- ⬜ `Pages/Staff/Orders.cshtml` - Quản lý đơn hàng

## Testing

### Test Cart Functions
1. Đăng nhập vào hệ thống
2. Vào trang sản phẩm `/Products`
3. Click vào chi tiết sản phẩm
4. Chọn size và màu
5. Click "Thêm vào giỏ hàng"
6. Kiểm tra:
   - ✅ Thông báo "Đã thêm vào giỏ hàng"
   - ✅ Badge số lượng trên icon giỏ hàng tăng lên
7. Click vào icon giỏ hàng
8. Kiểm tra trang giỏ hàng hiển thị đúng

### Test Profile
1. Click vào dropdown user
2. Chọn "Tài khoản"
3. Cập nhật thông tin
4. Click "Cập nhật"
5. Kiểm tra thông báo "Cập nhật thông tin thành công!"

### Test Orders
1. Click vào dropdown user
2. Chọn "Đơn hàng"
3. Kiểm tra danh sách đơn hàng hiển thị
4. Kiểm tra badge trạng thái đúng màu

## Kết Luận

✅ **Đã hoàn thành:**
- Cart Pages với đầy đủ chức năng CRUD
- Profile Page với cập nhật thông tin
- Orders Page với danh sách đơn hàng
- Cập nhật JavaScript để tương thích Razor Pages
- Build thành công không lỗi

✅ **Giải quyết được vấn đề:**
- Thêm vào giỏ hàng hoạt động
- Truy cập giỏ hàng OK
- Truy cập profile OK
- Xem lịch sử đơn hàng OK

🎉 Dự án giờ đây đã hoàn chỉnh với Razor Pages pattern!
