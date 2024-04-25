using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using System.Numerics;
using System.Threading.Tasks;

namespace HomeElectric.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userService.GetUser(Email, Password);
            if (user != null)
            {
                HttpContext.Session.SetString("Email", Email);
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("RoleId",
                        user.RoleId == 1 ? "Admin" :
                        user.RoleId == 2 ? "Staff" : "Customer");

                if (user.RoleId == 1)
                {
                    return RedirectToPage("/Admin/UserManager/Index");
                }
                else if (user.RoleId == 2)
                {
                    return RedirectToPage("/Staff/StaffDashBoard");
                }
                else
                {
                    return RedirectToPage("/Index");
                }
            }
            else
            {
                ErrorMessage = "Invalid email or password";
                return Page();
            }
        }

    }
}
