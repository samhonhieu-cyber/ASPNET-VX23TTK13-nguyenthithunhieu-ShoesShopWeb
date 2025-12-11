# Báo Cáo Tiến Độ Tuần 03

**Sinh viên:** Nguyễn Thị Thu Nhiêu  
**Lớp:** VX23TTK13  
**Tuần:** 03  
**Đồ án:** Website Bán Giày Online (ShoesShopWeb)

---

## Công Việc Đã Hoàn Thành

### 1. Tạo ViewModels

- `CartViewModel` - Quản lý giỏ hàng và các mục trong giỏ
- `CategoryViewModel` - Hiển thị và validation danh mục
- `ProductViewModel` - Hiển thị sản phẩm và biến thể
- `ProductFilterViewModel` - Lọc và phân trang sản phẩm
- `OrderViewModel` - Quản lý đơn hàng và thanh toán
- `DashboardViewModel` - Thống kê dashboard
- `LoginViewModel` & `RegisterViewModel` - Xác thực
- `UserManagementViewModel` - Quản lý người dùng

### 2. Giao diện khách hàng (Customer Pages)

**Trang sản phẩm:**

- `/Products/Index`: Danh sách sản phẩm với tìm kiếm, lọc (danh mục, khoảng giá), sắp xếp, phân trang (12 sản phẩm/trang)
- `/Products/Details`: Chi tiết sản phẩm, chọn màu sắc và kích cỡ, kiểm tra tồn kho, thêm vào giỏ

**Trang giỏ hàng:**

- `/Cart/Index`: Xem giỏ hàng, cập nhật số lượng, xóa sản phẩm, tính tổng tiền

**Trang đơn hàng:**

- `/Orders/Checkout`: Form nhập thông tin giao hàng, xem tóm tắt đơn hàng
- `/Orders/MyOrders`: Xem lịch sử đơn hàng

### 3. Layouts và Styling

**Layouts:**

- `_CustomerLayout.cshtml`: Navbar với dropdown user menu, cart badge, footer responsive
- `_StaffLayout.cshtml`: Sidebar navigation cố định, top bar, collapsible sidebar

**CSS Themes:**

- `customer.css`: White & Gray minimalist theme, smooth transitions, cart buttons (36x36px)
- `staff.css`: Dark sidebar (#2c3e50), clean table design, stat cards

**JavaScript:**

- `customer.js`: Cart operations, filters, notifications
- `staff.js`: Sidebar toggle, AJAX operations

### 4. Staff Management Pages

- `/Staff/Index`: Dashboard với 4 stat cards (Sản phẩm, Khách hàng, Danh mục, Đơn hàng)
- `/Staff/Products`: Quản lý sản phẩm (CRUD với modal)
- `/Staff/Categories`: Quản lý danh mục
- `/Staff/ProductVariants`: Quản lý biến thể (size, color, stock)
- `/Staff/Orders`: Quản lý đơn hàng, cập nhật trạng thái

### 5. Authentication & Authorization

- `/Account/Login`: Đăng nhập
- `/Account/Register`: Đăng ký
- Role-based authorization: Customer, Staff, Admin

---

## Kế Hoạch Tuần 04

- Testing toàn diện (Unit, Integration, UI/UX)
- Sửa lỗi phát hiện
- Tối ưu hóa code và performance
- Viết documentation đầy đủ
- Tổng số khách hàng
- Tổng số danh mục đang hoạt động

---

### 5. **Quản lý Danh mục (Categories)**

- ✅ `/Staff/Categories.cshtml` + `.cshtml.cs`
  - **CRUD hoàn chỉnh** qua modal popup
  - Table hiển thị: ID, Tên, Mô tả, Trạng thái
  - Handler methods:
    - `OnPostCreateAsync()` - Thêm danh mục mới
    - `OnPostUpdateAsync()` - Cập nhật danh mục
    - `OnPostDeleteAsync()` - Xóa (có kiểm tra sản phẩm)
    - `OnGetGetCategoryAsync()` - Lấy thông tin cho edit

**Tính năng:**

- Modal form với validation
- AJAX submit không reload trang
- Delete protection (kiểm tra có sản phẩm)
- Toggle active status
- TempData success messages

---

### 6. **Quản lý Sản phẩm (Products)**

- ✅ `/Staff/Products.cshtml` + `.cshtml.cs`
  - **CRUD đầy đủ** với modal form
  - Table với thumbnail image
  - Filter theo danh mục và search
  - Hiển thị tổng tồn kho từ variants
  - Button "Quản lý biến thể" link đến ProductVariants

**Handler methods:**

- `OnPostCreateAsync()` - Tạo sản phẩm
- `OnPostUpdateAsync()` - Cập nhật sản phẩm
- `OnPostDeleteAsync()` - Xóa (kiểm tra variants)
- `OnGetGetProductAsync()` - Load thông tin edit

**Fields:**

- ProductName, Description, CategoryId
- BasePrice, ImageUrl, IsActive

---

### 7. **Quản lý Biến thể sản phẩm (Product Variants)** ⭐ **MỚI**

- ✅ `/Staff/ProductVariants.cshtml` + `.cshtml.cs`
  - **CRUD hoàn chỉnh** cho biến thể màu/size
  - Breadcrumb navigation từ Products page
  - Table hiển thị: SKU, Màu (với preview box), Size, Giá, Tồn kho, Trạng thái
  - Modal form với dropdown màu sắc và kích cỡ

**Tính năng đặc biệt:**

- ✅ **Auto-generate SKU:** `PRD{productId}-CLR{colorId}-SZ{sizeId}`
- ✅ **Color preview box:** Hiển thị màu thực tế từ ColorCode
- ✅ **Stock badges:**
  - Green (>10), Yellow (1-10), Red (0)
- ✅ **Validation:** Không cho phép trùng combination (Product + Color + Size)
- ✅ **Delete protection:**
  - Không xóa được nếu đã có trong orders
  - Tự động xóa khỏi cart items khi xóa variant
- ✅ **Tổng tồn kho** hiển thị ở footer table

**Handler methods:**

- `OnGetAsync()` - Load variants cho 1 product
- `OnPostCreateAsync()` - Tạo variant với SKU auto-gen
- `OnPostUpdateAsync()` - Update variant (re-validate unique)
- `OnPostDeleteAsync()` - Xóa với order check
- `OnGetGetVariantAsync()` - Get variant details cho edit

**JavaScript features:**

- Auto-update SKU khi chọn color/size
- Color preview realtime
- AJAX form submission

---

### 8. **Quản lý Khách hàng (Customers)**

- ✅ `/Staff/Customers.cshtml` + `.cshtml.cs`
  - Danh sách tất cả khách hàng (chỉ role Customer)
  - Search theo tên hoặc email
  - Filter theo trạng thái (Active/Inactive)
  - View detail modal với thống kê:
    - Tổng số đơn hàng
    - Tổng giá trị chi tiêu
    - Thông tin cá nhân đầy đủ
  - Toggle active/inactive status

**Handler methods:**

- `OnGetGetCustomerAsync()` - Load chi tiết khách hàng
- `OnPostToggleStatusAsync()` - Bật/tắt trạng thái

**JavaScript features:**

- Filter realtime không reload
- AJAX toggle status với confirm dialog

---

### 9. **Quản lý Đơn hàng (Orders)**

- ✅ `/Staff/Orders.cshtml` + `.cshtml.cs`
  - Danh sách tất cả đơn hàng
  - Filter theo trạng thái (Pending, Processing, Shipping, Delivered, Cancelled)
  - Search theo mã đơn hoặc tên khách hàng
  - View detail modal hiển thị:
    - Thông tin đơn hàng
    - Thông tin khách hàng
    - Chi tiết sản phẩm với hình ảnh
    - Tổng tiền
  - **Dropdown actions** cập nhật trạng thái:
    - Pending → Processing
    - Processing → Shipping
    - Shipping → Delivered
    - Bất kỳ → Cancelled

**Handler methods:**

- `OnGetGetOrderAsync()` - Load order với items
- `OnPostUpdateStatusAsync()` - Cập nhật trạng thái
- `IsValidStatusTransition()` - Validate chuyển trạng thái hợp lệ

**Enum OrderStatus:**

```csharp
Pending = 0      // Chờ thanh toán
Processing = 1   // Đã xác nhận
Shipping = 2     // Đang giao hàng
Delivered = 3    // Đã giao
Cancelled = 4    // Đã hủy
```

---

## 🎨 Cải tiến UI/UX

### **Theme chính: White & Gray**

- Không sử dụng màu xanh Bootstrap
- Primary color: `#2d3436` (dark gray/black)
- Background: `#f8f9fa` (light gray)
- Text: `#2d3436` (almost black)
- Cards: White với shadow mềm

### **Cart buttons enhancement**

- Quantity +/- buttons: 36x36px
- Border radius: 8px
- Hover effect: background chuyển sang primary color
- Transform: translateY(-2px) khi hover
- Box shadow khi hover

### **Color preview trong Product Variants**

- 24x24px color box với border-radius 4px
- Border 1px solid #ddd
- Hiển thị trong table và dropdown select

### **Badges thống nhất**

- Stock badges: color-coded theo số lượng
- Status badges: Green (active), Secondary (inactive)
- Order status badges: Warning, Info, Primary, Success, Danger

---

## 🔧 Kiến trúc kỹ thuật

### **Razor Pages Pattern**

- Mỗi page có `.cshtml` (view) và `.cshtml.cs` (code-behind)
- Handler methods: `OnGet`, `OnPost`, `OnGetGetX`, `OnPostCreate`, `OnPostUpdate`, `OnPostDelete`
- `[BindProperty]` cho form binding
- `[Authorize(Roles = "Staff,Admin")]` cho staff pages

### **AJAX Operations**

- Fetch API với `RequestVerificationToken`
- JSON responses cho modal load
- No page reload cho better UX
- Success/Error notifications

### **Modal Forms**

- Bootstrap 5 modal component
- Clear form function trước khi mở
- Dual mode: Add (id=0) vs Edit (id>0)
- AJAX submit với FormData

### **Security**

- Anti-forgery tokens trong forms
- Authorization attributes
- Role-based access (Customer, Staff, Admin)
- Input validation với Data Annotations

---

## 📊 Database Schema sử dụng

```
Products → ProductVariants (1-N)
ProductVariants → Colors (N-1)
ProductVariants → Sizes (N-1)
ProductVariants → OrderItems (1-N)
ProductVariants → CartItems (1-N)
Orders → OrderItems (1-N)
Users (Customer) → Orders (1-N)
Users → Carts → CartItems
Categories → Products (1-N)
```

---

## 🚀 Tính năng nổi bật hoàn thành

1. ✅ **Auto-generate SKU** cho biến thể sản phẩm
2. ✅ **Color preview realtime** trong form và table
3. ✅ **Stock level badges** với color-coding
4. ✅ **Delete protection** với relationship checks
5. ✅ **Cart auto-cleanup** khi xóa variants
6. ✅ **Order status workflow** với validation
7. ✅ **Customer statistics** trong detail modal
8. ✅ **AJAX-based CRUD** không reload trang
9. ✅ **Responsive layouts** cho mobile
10. ✅ **Theme consistency** - White & Gray toàn bộ

---

## 🧪 Testing đã thực hiện

### **Functionality Testing**

- ✅ CRUD operations cho tất cả entities
- ✅ Validation rules (unique variants, delete protection)
- ✅ Order status transitions
- ✅ Cart operations
- ✅ Product filtering và pagination
- ✅ Modal forms (add/edit modes)

### **UI Testing**

- ✅ Responsive trên mobile/tablet/desktop
- ✅ Color preview display
- ✅ Button hover effects
- ✅ Notification messages
- ✅ Modal open/close animations

### **Build Status**

```bash
dotnet build
Build succeeded.
    0 Error(s)
    4 Warning(s) (nullable reference warnings - non-critical)
```

---

## 📝 Các file được tạo/sửa đổi

### **ViewModels (8 files)**

- CartViewModel.cs
- CategoryViewModel.cs
- ProductViewModel.cs
- ProductFilterViewModel.cs
- OrderViewModel.cs
- DashboardViewModel.cs
- LoginViewModel.cs, RegisterViewModel.cs
- UserManagementViewModel.cs

### **Customer Pages (3 files)**

- Products/Index.cshtml + Index.cshtml.cs
- Products/Details.cshtml.cs

### **Staff Pages (10 files)**

- Staff/Index.cshtml + Index.cshtml.cs
- Staff/Categories.cshtml + Categories.cshtml.cs
- Staff/Products.cshtml + Products.cshtml.cs
- Staff/ProductVariants.cshtml + ProductVariants.cshtml.cs ⭐
- Staff/Customers.cshtml + Customers.cshtml.cs
- Staff/Orders.cshtml + Orders.cshtml.cs

### **Layouts & Assets (6 files)**

- Shared/\_CustomerLayout.cshtml
- Shared/\_StaffLayout.cshtml
- wwwroot/css/customer.css (~430 lines)
- wwwroot/css/staff.css (~280 lines)
- wwwroot/js/customer.js (~210 lines)
- wwwroot/js/staff.js (~180 lines)

**Tổng cộng:** 27 files mới được tạo

---

## 📈 Thống kê mã nguồn

| Loại file          | Số lượng | Dòng code (ước tính) |
| ------------------ | -------- | -------------------- |
| `.cshtml`          | 9        | ~1,800               |
| `.cshtml.cs`       | 9        | ~1,500               |
| `.cs` (ViewModels) | 8        | ~400                 |
| `.css`             | 2        | ~710                 |
| `.js`              | 2        | ~390                 |
| **TỔNG**           | **30**   | **~4,800 dòng**      |

---

## 🎯 Mục tiêu tuần tới

### **Week 04 - Integration & Polish**

1. 📝 Hoàn thiện trang Checkout flow
2. 📝 Thêm Order Confirmation page
3. 📝 Implement Cart page với AJAX
4. 📝 Profile page cho Customer
5. 📝 My Orders page
6. 📝 Testing toàn diện
7. 📝 Performance optimization
8. 📝 Documentation

---

## 🐛 Known Issues & TODOs

- ⚠️ 4 nullable reference warnings (non-critical, có thể fix sau)
- 📝 Chưa có image upload (đang dùng URL)
- 📝 Chưa có email notifications
- 📝 Chưa có search history
- 📝 Chưa có product reviews

---

## 📖 Kết luận

Tuần 03 đã hoàn thành xuất sắc với việc xây dựng đầy đủ hệ thống quản lý staff. Điểm nổi bật là tính năng **Product Variants Management** với auto-SKU generation, color preview, và delete protection hoàn chỉnh. UI được cải thiện với theme White & Gray nhất quán, loại bỏ màu xanh Bootstrap. Tất cả CRUD operations đều hoạt động thông qua AJAX với modal forms, mang lại trải nghiệm người dùng mượt mà.

**Tiến độ tổng thể:** ~85% hoàn thành dự án. Chỉ còn phần checkout flow và một số tiện ích bổ sung cần hoàn thiện.

---

**Người báo cáo:** Nguyễn Thị Thu Nhiều  
**Ngày:** 18/11/2025  
**Chữ ký:** ********\_********
