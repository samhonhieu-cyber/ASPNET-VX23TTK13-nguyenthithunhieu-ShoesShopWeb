using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoesShopWeb.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ShoesShopWeb.Pages.Account;

[Authorize]
public class ProfileModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProfileModel> _logger;

    public ProfileModel(IUnitOfWork unitOfWork, ILogger<ProfileModel> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public string UserRole { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public class InputModel
    {
        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; } = string.Empty;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            Input = new InputModel
            {
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address ?? string.Empty
            };

            UserRole = user.Role.ToString();
            CreatedAt = user.CreatedAt;

            return Page();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading profile");
            return Page();
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            user.FullName = Input.FullName;
            user.PhoneNumber = Input.PhoneNumber;
            user.Address = Input.Address;

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            TempData["SuccessMessage"] = "Cập nhật thông tin thành công!";
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating profile");
            ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi cập nhật thông tin");
            return Page();
        }
    }
}
