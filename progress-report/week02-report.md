# Báo Cáo Tiến Độ Tuần 02

**Sinh viên:** Nguyễn Thị Thu Nhiêu  
**Lớp:** VX23TTK13  
**Tuần:** 02 (16/01/2025 - 23/01/2025)  
**Đồ án:** Website Bán Giày Online (ShoesShopWeb)

---

## 📋 Công Việc Đã Hoàn Thành

### 1. Repository Pattern Implementation ✅

**Generic Repository:**
- Tạo `IRepository<T>` interface với các operations cơ bản
- Implement `Repository<T>` với đầy đủ CRUD operations
- Hỗ trợ async/await patterns
- Tích hợp với Entity Framework Core

**Specific Repositories:**
- `IUserRepository` & `UserRepository` - Quản lý users với các methods đặc biệt:
  - GetByEmailAsync, EmailExistsAsync
  - GetUserWithCartAsync, GetUserWithOrdersAsync
  
- `IProductRepository` & `ProductRepository` - Quản lý products:
  - GetProductsByCategoryAsync
  - GetActiveProductsAsync
  - GetProductWithVariantsAsync
  - SearchProductsAsync
  
- `ICategoryRepository` & `CategoryRepository` - Quản lý categories:
  - GetCategoryWithProductsAsync
  - GetActiveCategoriesAsync
  
- `IOrderRepository` & `OrderRepository` - Quản lý orders:
  - GetOrdersByUserIdAsync
  - GetOrderWithDetailsAsync
  - GetOrdersByStatusAsync
  - GetRecentOrdersAsync

### 2. Unit of Work Pattern ✅

- Tạo `IUnitOfWork` interface
- Implement `UnitOfWork` class:
  - Quản lý tất cả repositories
  - Transaction management (Begin, Commit, Rollback)
  - SaveChanges coordination
  - Proper disposal pattern

**Repositories được quản lý:**
- Users, Products, Categories, Orders
- Carts, CartItems, OrderItems, Payments
- ProductVariants, Colors, Sizes

### 3. Business Logic Layer (BLL) ✅

**DTOs Created:**
- `UserDTOs.cs`: UserRegisterDto, UserLoginDto, UserDto, UserUpdateDto
- `ProductDTOs.cs`: ProductDto, ProductCreateDto, ProductUpdateDto
- `CategoryDTOs.cs`: CategoryDto, CategoryCreateDto, CategoryUpdateDto

**Service Interfaces:**
- `IUserService` - Authentication & user management
- `IProductService` - Product CRUD operations
- `ICategoryService` - Category management

**Service Implementations:**

**UserService:**
- RegisterAsync - Đăng ký user mới với validation
- LoginAsync - Xác thực đăng nhập
- GetUserByIdAsync, GetUserByEmailAsync
- UpdateProfileAsync - Cập nhật thông tin user
- ChangePasswordAsync - Đổi mật khẩu
- DeactivateUserAsync - Khóa tài khoản
- EmailExistsAsync - Kiểm tra email tồn tại

**ProductService:**
- GetAllProductsAsync, GetActiveProductsAsync
- GetProductsByCategoryAsync
- GetProductByIdAsync với variants
- SearchProductsAsync
- CreateProductAsync với validation
- UpdateProductAsync
- DeleteProductAsync (soft delete)

**CategoryService:**
- GetAllCategoriesAsync, GetActiveCategoriesAsync
- GetCategoryByIdAsync với products
- CreateCategoryAsync
- UpdateCategoryAsync
- DeleteCategoryAsync với validation (không xóa nếu có products)

### 4. Helper Classes ✅

**PasswordHasher:**
- HashPassword method sử dụng SHA256
- VerifyPassword method để kiểm tra mật khẩu
- Secure password storage

### 5. Database Seed Data ✅

**DbInitializer:**
- Seed 5 Categories (Thể Thao, Công Sở, Sneaker, Sandal, Boot)
- Seed 7 Colors (Đen, Trắng, Đỏ, Xanh Navy, Xám, Nâu, Xanh Lá)
- Seed 9 Sizes (36-44)
- Seed Admin User:
  - Email: admin@shoesshop.com
  - Password: Admin@123
  - Role: Admin

### 6. Dependency Injection Configuration ✅

**Program.cs Updates:**
- Đăng ký DbContext với PostgreSQL
- Đăng ký UnitOfWork
- Đăng ký tất cả Repositories (Scoped lifetime)
- Đăng ký tất cả Services (Scoped lifetime)
- Gọi DbInitializer để seed data khi app khởi động

---

## 📊 Thống Kê

| Hạng Mục | Số Lượng |
|----------|----------|
| Repository Interfaces | 5 |
| Repository Implementations | 5 |
| Service Interfaces | 3 |
| Service Implementations | 3 |
| DTOs | 10+ |
| Helper Classes | 1 |
| Seed Data Classes | 1 |
| Lines of Code Added | ~1500+ |

---

## 🎯 Mục Tiêu Đã Đạt

✅ 100% Repository Pattern với Generic & Specific implementations  
✅ 100% Unit of Work Pattern  
✅ 100% Service Layer với business logic  
✅ 100% DTOs cho data transfer  
✅ 100% Dependency Injection configuration  
✅ 100% Database seed data  
✅ Build project thành công  

---

## 🔧 Công Nghệ Đã Sử Dụng

### Design Patterns
- **Repository Pattern** - Data access abstraction
- **Unit of Work Pattern** - Transaction management
- **Dependency Injection** - Loose coupling
- **Service Layer Pattern** - Business logic separation
- **DTO Pattern** - Data transfer objects

### Best Practices
- Async/await patterns
- Interface-based programming
- SOLID principles
- Clean code architecture
- Proper error handling

---

## 📁 Cấu Trúc Code

```
ShoesShopWeb.DAL/
├── Data/
│   └── ApplicationDbContext.cs (DbContext với configurations)
├── Interfaces/
│   ├── IRepository.cs
│   ├── IUnitOfWork.cs
│   ├── IUserRepository.cs
│   ├── IProductRepository.cs
│   ├── ICategoryRepository.cs
│   └── IOrderRepository.cs
├── Repositories/
│   ├── Repository.cs (Generic)
│   ├── UnitOfWork.cs
│   ├── UserRepository.cs
│   ├── ProductRepository.cs
│   ├── CategoryRepository.cs
│   └── OrderRepository.cs
└── Seed/
    └── DbInitializer.cs

ShoesShopWeb.BLL/
├── Interfaces/
│   ├── IUserService.cs
│   ├── IProductService.cs
│   └── ICategoryService.cs
├── Services/
│   ├── UserService.cs
│   ├── ProductService.cs
│   └── CategoryService.cs
└── Helpers/
    └── PasswordHasher.cs

ShoesShopWeb.Entity/
└── DTOs/
    ├── UserDTOs.cs
    ├── ProductDTOs.cs
    └── CategoryDTOs.cs
```

---

## 🚀 Kế Hoạch Tuần 03

### 1. Database Migration
- [ ] Khởi động Docker PostgreSQL
- [ ] Cài đặt dotnet-ef tools
- [ ] Tạo migration InitialCreate
- [ ] Apply migration vào database
- [ ] Verify database schema

### 2. API Controllers
- [ ] Tạo AuthController (Login, Register)
- [ ] Tạo ProductsController (CRUD)
- [ ] Tạo CategoriesController (CRUD)
- [ ] Implement API responses standardization

### 3. Authentication & Authorization
- [ ] Implement JWT authentication
- [ ] Add authorization policies
- [ ] Protect API endpoints
- [ ] Session management

### 4. UI Development
- [ ] Tạo trang Home/Index
- [ ] Tạo trang Products listing
- [ ] Tạo trang Product details
- [ ] Trang Login/Register forms

---

## ⚠️ Vấn Đề Gặp Phải & Giải Quyết

### 1. **Circular dependency trong DbInitializer**
**Vấn đề:** DAL layer không nên reference BLL layer (PasswordHasher)

**Giải pháp:** Tạo local HashPassword method trong DbInitializer

### 2. **Model property mismatch**
**Vấn đề:** ApplicationDbContext sử dụng property names không khớp với Entity models

**Giải pháp:** 
- Kiểm tra các entity models
- Sửa property names trong DbContext configuration
- Sử dụng đúng: VariantId (không phải ProductVariantId), UnitPrice (không phải Price)

### 3. **EF Core version conflict warning**
**Vấn đề:** Version conflict giữa EF Core 9.0.1 và 9.0.10

**Giải pháp:** Warning không ảnh hưởng build, sẽ standardize versions sau

---

## 💡 Bài Học

1. **Repository Pattern Benefits:**
   - Separation of concerns
   - Easy testing với mock repositories
   - Centralized data access logic

2. **Unit of Work Importance:**
   - Transaction management
   - Coordinating multiple repository operations
   - Ensuring data consistency

3. **Service Layer Value:**
   - Business logic separation
   - Reusable business operations
   - Easy to test independently

4. **DTO Benefits:**
   - Data encapsulation
   - Validation at boundary
   - API versioning flexibility

5. **Dependency Injection Power:**
   - Loose coupling
   - Easy to swap implementations
   - Better testability

---

## 📝 Ghi Chú Kỹ Thuật

### Repository Pattern
```csharp
// Generic Repository cho common operations
IRepository<T> -> Repository<T>

// Specific repositories cho custom queries
IUserRepository : IRepository<User> -> UserRepository
```

### Unit of Work Pattern
```csharp
// Centralized repository management & transactions
UnitOfWork -> Users, Products, Categories, Orders...
```

### Service Layer
```csharp
// Business logic & validation
Service -> UnitOfWork -> Repositories -> DbContext
```

---

**Ngày báo cáo:** 16/01/2025  
**Tình trạng:** Hoàn thành đúng tiến độ ✅  
**Build Status:** ✅ Success (with 2 warnings)  
**Code Quality:** ✅ Clean & Well-structured
