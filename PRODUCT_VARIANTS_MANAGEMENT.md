# Trang Quản Lý Biến Thể Sản Phẩm (Product Variants)

## Ngày: 18/11/2025

### Vấn Đề
User báo: "quản lí biến thể ko dùng được"

### Nguyên Nhân
- Trong trang Products có link đến `/Staff/ProductVariants`
- Nhưng trang ProductVariants chưa được tạo
- Khi click vào nút "Quản lý biến thể" bị lỗi 404

### Giải Pháp

## Files Tạo Mới:
- ✅ `Pages/Staff/ProductVariants.cshtml`
- ✅ `Pages/Staff/ProductVariants.cshtml.cs`

---

## Chức Năng Trang Quản Lý Biến Thể

### 1. Thông Tin Hiển Thị

#### Header:
- Breadcrumb navigation: Sản phẩm → Biến thể
- Tên sản phẩm hiện tại
- Nút "Thêm biến thể"

#### Bảng Danh Sách Variants:
| Cột | Mô tả |
|-----|-------|
| SKU | Mã định danh duy nhất (code) |
| Màu sắc | Tên + preview màu (color box) |
| Kích cỡ | Size giày |
| Giá | Giá bán, so sánh với giá gốc |
| Tồn kho | Badge màu theo số lượng |
| Trạng thái | Hoạt động / Ngừng |
| Thao tác | Sửa / Xóa |

#### Footer Table:
- Tổng tồn kho của tất cả variants

### 2. Thêm Biến Thể

**Modal Form với các trường:**

#### Màu sắc (bắt buộc):
- Dropdown chọn từ danh sách Colors
- Chỉ hiện màu đang active
- **Color Preview**: hiển thị ô màu khi chọn

#### Kích cỡ (bắt buộc):
- Dropdown chọn từ danh sách Sizes
- Chỉ hiện size đang active

#### Giá (bắt buộc):
- Input number
- Mặc định = BasePrice của sản phẩm
- Có thể điều chỉnh cho từng variant
- Hiển thị giá gốc tham khảo

#### Tồn kho (bắt buộc):
- Input number
- Mặc định = 0
- Min = 0

#### SKU:
- **Tự động generate** theo pattern: `PRD{productId}-CLR{colorId}-SZ{sizeId}`
- Readonly field
- Ví dụ: `PRD5-CLR1-SZ3`

#### Trạng thái:
- Checkbox "Kích hoạt"
- Mặc định = checked

### 3. Sửa Biến Thể

- Load dữ liệu variant qua AJAX
- Điền sẵn tất cả thông tin vào form
- Cho phép thay đổi màu, size, giá, tồn kho
- SKU tự động cập nhật khi đổi màu/size
- Validation: không trùng với variant khác

### 4. Xóa Biến Thể

**Validation Rules:**
- ❌ Không cho xóa nếu variant đã có trong Order
- ✅ Có thể xóa nếu chỉ có trong Cart (tự động xóa khỏi cart)
- Confirmation dialog trước khi xóa

### 5. Business Logic

#### Auto-generate SKU:
```javascript
function updateSKU() {
    const productId = @Model.ProductId;
    const colorId = document.getElementById('colorId').value;
    const sizeId = document.getElementById('sizeId').value;
    
    if (colorId && sizeId) {
        const sku = `PRD${productId}-CLR${colorId}-SZ${sizeId}`;
        document.getElementById('sku').value = sku;
    }
}
```

#### Color Preview:
```javascript
function updateColorPreview() {
    const colorCode = selectedOption.getAttribute('data-color');
    preview.innerHTML = `<div style="width: 40px; height: 40px; 
                                     background-color: ${colorCode}; 
                                     border-radius: 8px; 
                                     border: 1px solid #ddd;"></div>`;
}
```

#### Validation Unique Variant:
```csharp
// Check combination: ProductId + ColorId + SizeId
var existingVariant = await _unitOfWork.ProductVariants.FirstOrDefaultAsync(
    v => v.ProductId == productId && 
         v.ColorId == colorId && 
         v.SizeId == sizeId
);

if (existingVariant != null)
{
    return BadRequest("Biến thể này đã tồn tại");
}
```

---

## Handlers trong Code-Behind

### OnGetAsync(int productId)
```csharp
- Load thông tin Product
- Load tất cả Variants của product
- Load Colors (chỉ active)
- Load Sizes (chỉ active)
- Load related data: Color, Size cho mỗi variant
```

### OnGetGetVariantAsync(int id)
```csharp
- Lấy thông tin 1 variant (JSON)
- Dùng cho Edit form
```

### OnPostCreateAsync(...)
```csharp
Parameters:
- productId, colorId, sizeId (required)
- sku (optional - auto-generate)
- price, stockQuantity
- isActive (default: true)

Validation:
- Check unique combination (product + color + size)
- Auto-generate SKU if empty

Result:
- Create ProductVariant entity
- Save to database
- Redirect back với TempData message
```

### OnPostUpdateAsync(...)
```csharp
Parameters:
- variantId (để update)
- productId, colorId, sizeId
- sku, price, stockQuantity, isActive

Validation:
- Variant exists?
- Check unique combination (exclude current variant)

Result:
- Update entity
- Save changes
- Redirect with success message
```

### OnPostDeleteAsync(int id)
```csharp
Validation:
1. Variant exists?
2. Check OrderItems (không cho xóa)
3. Check CartItems (xóa luôn nếu có)

Result:
- Delete CartItems first (if any)
- Delete Variant
- Redirect with message
```

---

## UI/UX Features

### 1. Badge Colors cho Tồn Kho
```css
Stock > 10     → bg-success (xanh)
Stock 1-10     → bg-warning (vàng)
Stock = 0      → bg-danger (đỏ)
```

### 2. Color Box Preview
```html
<span class="color-box" 
      style="background-color: #FF0000; 
             width: 24px; height: 24px; 
             border-radius: 4px; 
             border: 1px solid #ddd;">
</span>
```

### 3. Price Comparison
- Hiển thị giá variant
- Nếu khác BasePrice → show giá gốc dưới dạng small text

### 4. Breadcrumb Navigation
```
Sản phẩm → Biến thể - {ProductName}
```
- Link back về Products page

### 5. Footer Summary
- Tổng tồn kho = Sum(all variants.StockQuantity)
- Hiển thị badge primary

---

## Security & Validation

### Authorization:
```csharp
[Authorize(Roles = "Admin,Staff")]
```

### Anti-forgery:
- Token trong AJAX POST requests
- Server-side validation

### Input Validation:
- Required fields: Color, Size, Price, StockQuantity
- Min values: Price >= 0, Stock >= 0
- Unique constraint: Product + Color + Size

### Error Handling:
- Try-catch trong tất cả handlers
- Log errors với ILogger
- Return BadRequest với message rõ ràng
- TempData cho success/error messages

---

## Integration với Products Page

### Link từ Products:
```html
<a asp-page="/Staff/ProductVariants" 
   asp-route-productId="@product.ProductId" 
   class="btn btn-sm btn-secondary">
    <i class="fas fa-cogs"></i>
</a>
```

### Hiển thị Tổng Tồn Kho:
```razor
@{
    var totalStock = product.ProductVariants?.Sum(v => v.StockQuantity) ?? 0;
}
<span class="badge @(totalStock > 10 ? "bg-success" : ...)">
    @totalStock
</span>
```

---

## Ví Dụ Dữ Liệu

### Sản phẩm: Nike Air Max 2024

| SKU | Màu | Size | Giá | Tồn kho |
|-----|-----|------|-----|---------|
| PRD1-CLR1-SZ1 | Đen | 39 | 2,500,000 đ | 25 |
| PRD1-CLR1-SZ2 | Đen | 40 | 2,500,000 đ | 30 |
| PRD1-CLR2-SZ1 | Trắng | 39 | 2,600,000 đ | 15 |
| PRD1-CLR2-SZ2 | Trắng | 40 | 2,600,000 đ | 20 |

**Tổng tồn kho: 90**

---

## Kết Quả

### Trước khi sửa:
- ❌ Link "Quản lý biến thể" bị 404
- ❌ Không thể thêm/sửa/xóa variants
- ❌ Không xem được chi tiết variants

### Sau khi sửa:
- ✅ Trang ProductVariants hoạt động đầy đủ
- ✅ Thêm/Sửa/Xóa variants qua modal
- ✅ Auto-generate SKU
- ✅ Color preview khi chọn màu
- ✅ Validation đầy đủ
- ✅ UI đẹp với badges, color boxes
- ✅ Real-time SKU update
- ✅ Breadcrumb navigation

### Build Status:
```
✅ Build succeeded
⚠️  Warnings về nullable (không ảnh hưởng)
```

---

## Navigation Flow

```
Staff Dashboard
    ↓
Quản lý Sản phẩm (/Staff/Products)
    ↓ [Click nút Quản lý biến thể]
Quản lý Biến thể (/Staff/ProductVariants?productId=X)
    ↓ [Breadcrumb]
Quay lại Sản phẩm
```

Trang quản lý biến thể giờ đã hoạt động hoàn chỉnh! 🎉
