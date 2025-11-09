# ShoesShopWeb - Đồ Án ASP.NET Core

## 📋 Thông Tin Đồ Án

**Tên đồ án:** Website Bán Giày Online (ShoesShopWeb)

**Công nghệ sử dụng:**
- ASP.NET Core 9.0
- Entity Framework Core 9.0
- PostgreSQL 16
- Razor Pages
- Docker & Docker Compose

**Kiến trúc:** N-Layer Architecture (Entity, DAL, BLL, Presentation)

---

## 🏗️ Cấu Trúc Dự Án

```
project_ASP.NET/
├── docker/                    # Docker configuration files
│   ├── docker-compose.yml    # PostgreSQL container configuration
│   ├── .env                  # Environment variables (development)
│   └── .env.example          # Environment variables template
├── src/
│   └── ShoesShopWeb/
│       ├── ShoesShopWeb/              # Presentation Layer - Web Application
│       │   ├── Controllers/           # API Controllers
│       │   ├── Pages/                 # Razor Pages
│       │   ├── ViewModels/           # View Models
│       │   ├── Helpers/              # Helper classes
│       │   ├── wwwroot/              # Static files (CSS, JS, images)
│       │   ├── appsettings.json      # Application configuration
│       │   └── Program.cs            # Application entry point
│       ├── ShoesShopWeb.BLL/         # Business Logic Layer
│       │   ├── Services/             # Business services
│       │   ├── Interfaces/           # Service interfaces
│       │   └── Validators/           # Business validation logic
│       ├── ShoesShopWeb.DAL/         # Data Access Layer
│       │   ├── Data/                 # DbContext
│       │   ├── Repositories/         # Repository pattern implementation
│       │   └── Interfaces/           # Repository interfaces
│       └── ShoesShopWeb.Entity/      # Entity Layer
│           ├── Models/               # Database models/entities
│           ├── DTOs/                 # Data Transfer Objects
│           └── Enums/                # Enumerations
├── progress-report/          # Báo cáo tiến độ
├── thesis/                   # Tài liệu đồ án
└── README.md                 # File documentation này
```

---

## 🚀 Cài Đặt và Chạy Dự Án

### Yêu Cầu Hệ Thống

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Git](https://git-scm.com/)
- IDE: Visual Studio 2022, Rider, hoặc VS Code

### Bước 1: Clone Repository

```bash
git clone https://github.com/samhonhieu-cyber/ASPNET-VX23TTK13-nguyenthithunhieu-ShoesShopWeb.git
cd ASPNET-VX23TTK13-nguyenthithunhieu-ShoesShopWeb
```

### Bước 2: Cấu Hình Môi Trường

1. Di chuyển vào thư mục `docker`:
```bash
cd docker
```

2. Copy file `.env.example` thành `.env` (nếu chưa có):
```bash
cp .env.example .env
```

3. Chỉnh sửa file `.env` nếu cần thiết (thay đổi mật khẩu database, port, v.v.)

### Bước 3: Khởi Động Database

```bash
# Đảm bảo đang ở thư mục docker
cd docker

# Khởi động PostgreSQL container
docker-compose up -d

# Kiểm tra container đang chạy
docker-compose ps

# Xem logs nếu cần
docker-compose logs postgres

# Quay lại thư mục gốc
cd ..
```

**Lưu ý:** Container PostgreSQL sẽ chạy ở port 5432 (mặc định). Data sẽ được lưu trong Docker volume `postgres_data`.

### Bước 4: Cập Nhật Connection String

Mở file `src/ShoesShopWeb/ShoesShopWeb/appsettings.json` và thêm connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=shoesshop_db;Username=postgres;Password=postgres123"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Bước 5: Restore Dependencies

```bash
# Từ thư mục gốc của repository
cd src/ShoesShopWeb
dotnet restore
```

### Bước 6: Chạy Migration (Khi đã tạo migrations)

```bash
# Di chuyển đến project chính
cd src/ShoesShopWeb/ShoesShopWeb

# Chạy migrations
dotnet ef database update

# Nếu cần tạo migration mới
dotnet ef migrations add InitialCreate
```

### Bước 7: Chạy Application

```bash
# Đảm bảo đang ở thư mục src/ShoesShopWeb/ShoesShopWeb
cd src/ShoesShopWeb/ShoesShopWeb

# Chạy application
dotnet run

# Hoặc chạy với watch mode (tự động reload khi có thay đổi)
dotnet watch run
```

Application sẽ chạy tại:
- HTTP: http://localhost:5000
- HTTPS: https://localhost:5001

### 🎯 Quick Start (Chạy Nhanh)

```bash
# 1. Khởi động database
cd docker && docker-compose up -d && cd ..

# 2. Chạy application
cd src/ShoesShopWeb/ShoesShopWeb && dotnet run
```

---

## 🗄️ Quản Lý Database

### Kết Nối Database

**Thông tin kết nối mặc định:**
- Host: `localhost`
- Port: `5432`
- Database: `shoesshop_db`
- Username: `postgres`
- Password: `postgres123`

### Entity Framework Core Migrations

```bash
# Tạo migration mới
dotnet ef migrations add MigrationName

# Cập nhật database
dotnet ef database update

# Rollback migration
dotnet ef database update PreviousMigrationName

# Xóa migration cuối cùng (chưa apply)
dotnet ef migrations remove
```

### Docker Commands

**Lưu ý:** Tất cả các lệnh Docker phải chạy từ thư mục `docker/`

```bash
# Di chuyển vào thư mục docker
cd docker

# Khởi động containers
docker-compose up -d

# Dừng containers
docker-compose down

# Dừng và xóa volumes (xóa toàn bộ data)
docker-compose down -v

# Restart containers
docker-compose restart

# Xem logs
docker-compose logs -f postgres

# Kiểm tra trạng thái
docker-compose ps

# Kết nối vào PostgreSQL shell
docker-compose exec postgres psql -U postgres -d shoesshop_db
```

---

## 📦 Các Package NuGet Đã Sử dụng

### ShoesShopWeb (Presentation Layer)
- `Microsoft.EntityFrameworkCore.Tools` - EF Core Tools

### Các package sẽ được thêm (dự kiến):
- `Npgsql.EntityFrameworkCore.PostgreSQL` - PostgreSQL provider
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` - Identity system
- `AutoMapper` - Object mapping
- `FluentValidation` - Validation
- `Serilog` - Logging

---

## 🔧 Cấu Hình Dự Án

### docker/.env

File cấu hình cho Docker container (PostgreSQL):

```bash
# Database Configuration
POSTGRES_DB=shoesshop_db
POSTGRES_USER=postgres
POSTGRES_PASSWORD=postgres123
POSTGRES_PORT=5432

# Application Configuration
ASPNETCORE_ENVIRONMENT=Development
ASPNETCORE_URLS=http://+:5000;https://+:5001

# Connection String
CONNECTION_STRING=Host=localhost;Port=5432;Database=shoesshop_db;Username=postgres;Password=postgres123
```

### appsettings.json

File cấu hình chính của ứng dụng (`src/ShoesShopWeb/ShoesShopWeb/appsettings.json`):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=shoesshop_db;Username=postgres;Password=postgres123"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**Quan trọng:** Connection string trong `appsettings.json` phải khớp với cấu hình trong `docker/.env`

---

## 📝 Các Tính Năng Đã Thực Hiện

### Sprint 1 - Khởi Tạo Dự Án (Hiện tại)
- [x] Khởi tạo solution và các project theo kiến trúc N-Layer
- [x] Cấu hình Docker Compose cho PostgreSQL
- [x] Thiết lập cấu trúc thư mục cơ bản
- [x] Tạo file README.md

### Sprint 2 - Database & Models (Dự kiến)
- [ ] Thiết kế database schema
- [ ] Tạo các Entity models
- [ ] Implement DbContext
- [ ] Tạo và chạy migrations
- [ ] Seed initial data

### Sprint 3 - Repository & Service Layer (Dự kiến)
- [ ] Implement Generic Repository pattern
- [ ] Tạo các specific repositories
- [ ] Implement business services
- [ ] Unit of Work pattern

### Sprint 4 - Authentication & Authorization (Dự kiến)
- [ ] Implement ASP.NET Core Identity
- [ ] User registration
- [ ] User login/logout
- [ ] Role-based authorization
- [ ] JWT token authentication (cho API)

### Sprint 5 - Product Management (Dự kiến)
- [ ] CRUD sản phẩm
- [ ] Quản lý danh mục sản phẩm
- [ ] Upload và quản lý hình ảnh
- [ ] Tìm kiếm và lọc sản phẩm
- [ ] Phân trang

### Sprint 6 - Shopping Cart & Checkout (Dự kiến)
- [ ] Thêm sản phẩm vào giỏ hàng
- [ ] Cập nhật giỏ hàng
- [ ] Checkout process
- [ ] Order management

### Sprint 7 - Additional Features (Dự kiến)
- [ ] User profile management
- [ ] Order history
- [ ] Product reviews
- [ ] Admin dashboard
- [ ] Reports

---

## 🎨 Giao Diện Người Dùng

### Trang Chính
- Danh sách sản phẩm nổi bật
- Các danh mục sản phẩm
- Banner quảng cáo
- Tìm kiếm sản phẩm

### Trang Quản Trị
- Dashboard thống kê
- Quản lý sản phẩm
- Quản lý đơn hàng
- Quản lý người dùng
- Báo cáo

---

## 🧪 Testing

```bash
# Từ thư mục src/ShoesShopWeb
cd src/ShoesShopWeb

# Chạy unit tests (khi đã có test project)
dotnet test

# Chạy tests với coverage
dotnet test /p:CollectCoverage=true
```

---

## ⚠️ Troubleshooting

### Lỗi kết nối Database

**Vấn đề:** Không thể kết nối đến PostgreSQL

**Giải pháp:**
```bash
# 1. Kiểm tra container có đang chạy không
cd docker && docker-compose ps

# 2. Kiểm tra logs
docker-compose logs postgres

# 3. Restart container
docker-compose restart postgres

# 4. Kiểm tra port có bị conflict không
lsof -i :5432
```

### Lỗi Migration

**Vấn đề:** `dotnet ef` command not found

**Giải pháp:**
```bash
# Cài đặt EF Core tools globally
dotnet tool install --global dotnet-ef

# Hoặc update nếu đã cài
dotnet tool update --global dotnet-ef
```

### Lỗi Port đã được sử dụng

**Vấn đề:** Port 5432 hoặc 5000/5001 đã được sử dụng

**Giải pháp:**
```bash
# Kiểm tra process đang dùng port
lsof -i :5432
lsof -i :5000

# Kill process nếu cần
kill -9 <PID>

# Hoặc thay đổi port trong docker/.env và appsettings.json
```

---

## 📚 Tài Liệu Tham Khảo

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [Docker Documentation](https://docs.docker.com/)
- [Markdown Guide](https://www.markdownguide.org/)

---

## 👥 Thông Tin Sinh Viên

**Họ và tên:** Nguyễn Thị Thu Nhiêu
**Lớp:** VX23TTK13
**MSSV:** [Điền MSSV]
**Email:** [Điền email]

**Giảng viên hướng dẫn:** [Tên giảng viên]

---

## 📄 License

Dự án này được phát triển cho mục đích học tập tại trường Đại học [Tên trường].

---

## 📞 Liên Hệ

Nếu có bất kỳ câu hỏi hoặc vấn đề nào, vui lòng liên hệ qua:
- GitHub Issues: [Link to issues]
- Email: [Email sinh viên]

---

## 🔄 Changelog

### [Version 0.1.0] - 2025-01-09
- Khởi tạo dự án với kiến trúc N-Layer
- Cấu hình Docker Compose cho PostgreSQL
- Tạo cấu trúc thư mục cơ bản
- Thiết lập documentation

---

**Lưu ý:** File README này sẽ được cập nhật liên tục trong quá trình phát triển đồ án.
