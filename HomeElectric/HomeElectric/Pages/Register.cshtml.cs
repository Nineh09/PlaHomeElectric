using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HomeElectric.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters")]
        public string FullName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(@"^\w+([\.-]?\w+)*@gmail\.com$", ErrorMessage = "Email must be a Gmail address. example@gmail.com")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter a password")]
        [MinLength(5, ErrorMessage = "Password must be at least 5 characters")]
        public string Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression(@"^09\d{8}$", ErrorMessage = "Invalid phone number. Phone number must start with '09' and have 10 digits.")]
        public string Phone { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostRegisterAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (Password != ConfirmPassword)
                {
                    ErrorMessage = "Passwords do not match.";
                    return Page();
                }

                //var user = await _userService.CreateUser(FullName, Email, Password, ConfirmPassword, Phone);
                //SuccessMessage = "Registration successful! Redirecting to login page...";
                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }

    }
}
