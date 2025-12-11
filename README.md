# 👟 ShoesShopWeb - Website Bán Giày Online

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-4169E1?logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Docker](https://img.shields.io/badge/Docker-Compose-2496ED?logo=docker&logoColor=white)](https://www.docker.com/)

> Đồ án ASP.NET Core - Website thương mại điện tử bán giày với đầy đủ tính năng quản lý sản phẩm, giỏ hàng, đơn hàng

---

## 📋 Giới Thiệu

**ShoesShopWeb** là website bán giày trực tuyến được xây dựng bằng ASP.NET Core 9.0 với kiến trúc N-Layer. Dự án bao gồm đầy đủ tính năng cho khách hàng (duyệt sản phẩm, giỏ hàng, đặt hàng) và quản trị viên (quản lý sản phẩm, đơn hàng, khách hàng).

**Công nghệ sử dụng:**

- Backend: ASP.NET Core 9.0, Entity Framework Core 9.0
- Database: PostgreSQL 16 (Docker)
- Frontend: Razor Pages, Bootstrap 5, JavaScript
- Kiến trúc: N-Layer (Entity → DAL → BLL → Presentation)

**Tính năng chính:**

- ✅ Quản lý sản phẩm với biến thể (màu sắc, kích cỡ)
- ✅ Giỏ hàng và đặt hàng trực tuyến
- ✅ Phân quyền người dùng (Admin, Staff, Customer)
- ✅ Dashboard thống kê và báo cáo
- ✅ Responsive design (mobile, tablet, desktop)

**Sinh viên:** Nguyễn Thị Thu Nhiều - VX23TTK13

---

## 🚀 Hướng Dẫn Cài Đặt và Chạy (Windows)

### Yêu cầu hệ thống

Trước khi bắt đầu, bạn cần cài đặt:

1. **Git** - Tải code từ GitHub

   - Download: https://git-scm.com/download/win
   - Cài đặt: Double-click file `.exe` và nhấn Next → Next → Install

2. **.NET 9.0 SDK** - Chạy ứng dụng ASP.NET Core

   - Download: https://dotnet.microsoft.com/download/dotnet/9.0
   - Chọn: "Download .NET 9.0 SDK x64" cho Windows
   - Cài đặt: Double-click file `.exe` và làm theo hướng dẫn

3. **Docker Desktop** - Chạy PostgreSQL database
   - Download: https://www.docker.com/products/docker-desktop
   - Cài đặt: Double-click file `.exe` và làm theo hướng dẫn
   - **Lưu ý:** Sau khi cài xong, mở Docker Desktop và đảm bảo nó đang chạy (biểu tượng Docker hiện ở system tray)

### Các bước chạy dự án

**Bước 1: Clone dự án từ GitHub**

Mở **Command Prompt** (cmd) hoặc **PowerShell** và chạy:

```cmd
git clone https://github.com/samhonhieu-cyber/ASPNET-VX23TTK13-nguyenthithunhieu-ShoesShopWeb.git
cd ASPNET-VX23TTK13-nguyenthithunhieu-ShoesShopWeb
```

**Bước 2: Khởi động PostgreSQL database**

```cmd
cd docker
docker-compose up -d
docker-compose ps
cd ..
```

**Kiểm tra:** Lệnh `docker-compose ps` phải hiển thị trạng thái "healthy". Nếu không, chờ 10-20 giây và chạy lại lệnh.

**Bước 3: Chạy ứng dụng**

```cmd
cd src\ShoesShopWeb\ShoesShopWeb
dotnet restore
dotnet build
dotnet run --launch-profile https
```

**Bước 4: Mở trình duyệt**

Truy cập: **https://localhost:7114**

- Nếu trình duyệt hiển thị cảnh báo SSL, nhấn "Advanced" → "Proceed" (an toàn cho môi trường development)

### Chạy nhanh (một lệnh)

Sau khi đã cài đặt đủ yêu cầu, bạn có thể chạy nhanh bằng một lệnh:

```cmd
cd docker && docker-compose up -d && cd ..\src\ShoesShopWeb\ShoesShopWeb && dotnet run --launch-profile https
```

---

## 🔐 Tài Khoản Thử Nghiệm

Sử dụng các tài khoản sau để đăng nhập:

| Vai trò  | Email                  | Mật khẩu     |
| -------- | ---------------------- | ------------ |
| Admin    | admin@shoesshop.com    | Admin@123    |
| Staff    | staff@shoesshop.com    | Staff@123    |
| Customer | customer@shoesshop.com | Customer@123 |

---

## 📂 Cấu Trúc Dự Án

```
├── src/
│   └── ShoesShopWeb/
│       ├── ShoesShopWeb/              # Presentation Layer (Razor Pages)
│       ├── ShoesShopWeb.BLL/          # Business Logic Layer
│       ├── ShoesShopWeb.DAL/          # Data Access Layer
│       └── ShoesShopWeb.Entity/       # Entity Models
├── docker/
│   └── docker-compose.yml             # PostgreSQL container
└── progress-report/                   # Báo cáo tiến độ hàng tuần
```

---

## ⚠️ Xử Lý Lỗi Thường Gặp

### Lỗi: "Cannot connect to database"

**Nguyên nhân:** PostgreSQL chưa khởi động hoặc chưa sẵn sàng

**Giải pháp:**

```cmd
cd docker
docker-compose restart
docker-compose ps
```

Đợi cho đến khi trạng thái hiển thị "healthy" (có thể mất 10-20 giây)

### Lỗi: "Port 7114 already in use"

**Nguyên nhân:** Cổng đang được sử dụng bởi ứng dụng khác

**Giải pháp:**

- Dừng ứng dụng đang chạy trên cổng 7114
- Hoặc thay đổi cổng trong `launchSettings.json`

### Lỗi: "Docker daemon is not running"

**Nguyên nhân:** Docker Desktop chưa được khởi động

**Giải pháp:**

- Mở Docker Desktop
- Đợi cho đến khi biểu tượng Docker hiện ở system tray
- Chạy lại lệnh `docker-compose up -d`

### Lỗi: "dotnet command not found"

**Nguyên nhân:** .NET SDK chưa được cài đặt hoặc chưa có trong PATH

**Giải pháp:**

- Cài đặt lại .NET 9.0 SDK từ https://dotnet.microsoft.com/download/dotnet/9.0
- Khởi động lại Command Prompt/PowerShell
- Kiểm tra: `dotnet --version`

---

## 📚 Tài Liệu Tham Khảo

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [Docker Documentation](https://docs.docker.com/)

### Báo cáo tiến độ hàng tuần

Chi tiết trong thư mục `progress-report/`:

- [Week 01](progress-report/week01-report.md) - Setup dự án, database schema
- [Week 02](progress-report/week02-report.md) - Repository Pattern, BLL Services
- [Week 03](progress-report/week03-report.md) - ViewModels, Customer & Staff Pages
- [Week 04](progress-report/week04-report.md) - Testing, Bug Fixes, Optimization
- [Week 05](progress-report/week05-report.md) - Final Polish, Documentation

---

## 👥 Thông Tin

**Sinh viên:** Nguyễn Thị Thu Nhiều  
**Lớp:** VX23TTK13

**Repository:** [github.com/samhonhieu-cyber/ASPNET-VX23TTK13-nguyenthithunhieu-ShoesShopWeb](https://github.com/samhonhieu-cyber/ASPNET-VX23TTK13-nguyenthithunhieu-ShoesShopWeb)

---

<div align="center">

**⭐ Dự án hoàn thành 100% - Sẵn sàng demo! ⭐**

Made with ❤️ using ASP.NET Core 9.0

</div>
