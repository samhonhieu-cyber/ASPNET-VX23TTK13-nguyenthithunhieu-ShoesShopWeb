# Báo Cáo Tiến Độ Tuần 01

**Sinh viên:** Nguyễn Thị Thu Nhiêu  
**Lớp:** VX23TTK13  
**Tuần:** 01 (09/01/2025 - 16/01/2025)  
**Đồ án:** Website Bán Giày Online (ShoesShopWeb)

---

## 📋 Công Việc Đã Hoàn Thành

### 1. Khởi Tạo Dự Án ✅
- Tạo Solution với kiến trúc N-Layer (4 projects):
  - `ShoesShopWeb` - Presentation Layer (ASP.NET Core Razor Pages)
  - `ShoesShopWeb.BLL` - Business Logic Layer
  - `ShoesShopWeb.DAL` - Data Access Layer
  - `ShoesShopWeb.Entity` - Entity/Models Layer

### 2. Thiết Kế Database Schema ✅
**11 Models đã tạo:**
- User (Người dùng)
- Category (Danh mục sản phẩm)
- Product (Sản phẩm)
- Color (Màu sắc)
- Size (Kích cỡ)
- ProductVariant (Biến thể sản phẩm: màu + size)
- Cart (Giỏ hàng)
- CartItem (Sản phẩm trong giỏ hàng)
- Order (Đơn hàng)
- OrderItem (Sản phẩm trong đơn hàng)
- Payment (Thanh toán)

### 3. Cấu Hình Database ✅
- Tạo `ApplicationDbContext` với đầy đủ DbSets
- Cấu hình relationships và constraints:
  - Primary Keys, Foreign Keys
  - One-to-One, One-to-Many relationships
  - Unique constraints (Email)
  - Delete behaviors
  - Column types (decimal cho giá)

### 4. Setup Docker & PostgreSQL ✅
- Tạo `docker-compose.yml` cho PostgreSQL 16
- Cấu hình environment variables (`.env`, `.env.example`)
- Container name: `shoesshop_postgres`
- Database: `shoesshop_db`
- Port: 5432

### 5. Cấu Hình Entity Framework Core ✅
**Packages đã cài:**
- `Npgsql.EntityFrameworkCore.PostgreSQL` v9.0.4
- `Microsoft.EntityFrameworkCore` v9.0.10
- `Microsoft.EntityFrameworkCore.Design` v9.0.10
- `Microsoft.EntityFrameworkCore.Tools` v9.0.10

**Cấu hình:**
- Connection string trong `appsettings.json`
- Đăng ký DbContext trong `Program.cs`
- Logging cho EF Core queries

### 6. Documentation ✅
- `README.md` - Hướng dẫn cài đặt và chạy project
- `MIGRATION_GUIDE.md` - Hướng dẫn chi tiết về migration
- `.gitignore` - Bảo vệ files nhạy cảm

---

## 📊 Thống Kê

| Hạng Mục | Số Lượng |
|----------|----------|
| Projects | 4 |
| Models | 11 |
| DbSets | 11 |
| Docker Services | 1 (PostgreSQL) |
| Documentation Files | 3 |

---

## 🎯 Mục Tiêu Đã Đạt

✅ Hoàn thành 100% setup ban đầu  
✅ Database schema design hoàn chỉnh  
✅ Docker containerization  
✅ EF Core configuration  
✅ Project documentation  

---

## 🚀 Kế Hoạch Tuần 02

### 1. Database Migration
- [ ] Chạy migration đầu tiên
- [ ] Verify database schema
- [ ] Seed initial data (Categories, Colors, Sizes)

### 2. Repository Pattern
- [ ] Tạo Generic Repository interface & implementation
- [ ] Implement specific repositories:
  - UserRepository
  - ProductRepository
  - CategoryRepository
  - OrderRepository

### 3. Business Logic Layer
- [ ] Tạo service interfaces
- [ ] Implement UserService (đăng ký, đăng nhập)
- [ ] Implement ProductService (CRUD cơ bản)

### 4. Authentication
- [ ] Implement ASP.NET Core Identity hoặc custom authentication
- [ ] User registration
- [ ] User login/logout

---

## 📝 Ghi Chú

### Công Nghệ Sử Dụng
- **Framework:** ASP.NET Core 9.0
- **Database:** PostgreSQL 16
- **ORM:** Entity Framework Core 9.0
- **Container:** Docker & Docker Compose
- **IDE:** Visual Studio Code / Rider

### Kiến Trúc
```
Presentation (Web) → BLL (Services) → DAL (Repositories) → Entity (Models) → Database
```

### Git Repository
- Repository: `ASPNET-VX23TTK13-nguyenthithunhieu-ShoesShopWeb`
- Owner: samhonhieu-cyber
- Branch: main

---

## ⚠️ Vấn Đề Gặp Phải

1. **Docker daemon chưa chạy** - Đã hướng dẫn khởi động Docker Desktop
2. **Connection string ban đầu chưa khớp** - Đã cập nhật để phù hợp với docker/.env

---

## 💡 Bài Học

1. Importance of proper architecture planning (N-Layer)
2. Database design với relationships phức tạp
3. Docker containerization cho development environment
4. Entity Framework Core configuration và best practices
5. Documentation trong quá trình phát triển

---

**Ngày báo cáo:** 16/01/2025  
**Tình trạng:** Hoàn thành đúng tiến độ ✅
