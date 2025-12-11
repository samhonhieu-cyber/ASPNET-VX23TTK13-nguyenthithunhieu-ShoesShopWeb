# Báo Cáo Tiến Độ Tuần 01

**Sinh viên:** Nguyễn Thị Thu Nhiêu  
**Lớp:** VX23TTK13  
**Tuần:** 01 (09/01/2025 - 16/01/2025)  
**Đồ án:** Website Bán Giày Online (ShoesShopWeb)

---

## Công Việc Đã Hoàn Thành

### 1. Khởi tạo dự án

- Tạo Solution với kiến trúc N-Layer (4 projects)
  - `ShoesShopWeb` - Presentation Layer (ASP.NET Core Razor Pages)
  - `ShoesShopWeb.BLL` - Business Logic Layer
  - `ShoesShopWeb.DAL` - Data Access Layer
  - `ShoesShopWeb.Entity` - Entity/Models Layer

### 2. Thiết kế Database Schema

- Tạo 11 Models: User, Category, Product, Color, Size, ProductVariant, Cart, CartItem, Order, OrderItem, Payment
- Tạo `ApplicationDbContext` với đầy đủ DbSets
- Cấu hình relationships: Primary Keys, Foreign Keys, One-to-One, One-to-Many
- Cấu hình constraints: Unique (Email), Delete behaviors, Column types (decimal)

### 3. Setup Docker & PostgreSQL

- Tạo `docker-compose.yml` cho PostgreSQL 16
- Cấu hình environment variables (`.env`, `.env.example`)
- Database: `shoesshop_db`, Port: 5432

### 4. Cấu hình Entity Framework Core

- Cài đặt packages: Npgsql.EntityFrameworkCore.PostgreSQL v9.0.4, EF Core v9.0.10
- Cấu hình Connection string trong `appsettings.json`
- Đăng ký DbContext và Logging trong `Program.cs`

### 5. Viết tài liệu

- `README.md` - Hướng dẫn cài đặt và chạy project
- `MIGRATION_GUIDE.md` - Hướng dẫn migration
- `.gitignore` - Bảo vệ files nhạy cảm

---

## Kế Hoạch Tuần 02

- Chạy migration đầu tiên và verify database schema
- Seed initial data (Categories, Colors, Sizes)
- Tạo Generic Repository interface & implementation
- Implement specific repositories (User, Product, Category, Order)
- Tạo Unit of Work pattern
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
