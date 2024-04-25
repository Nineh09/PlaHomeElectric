using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Service.Interface;
using CloudinaryDotNet.Actions;
using System.ComponentModel.DataAnnotations;

namespace HomeElectric.Pages.Admin.UserManager
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public CreateModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public async Task<IActionResult> OnGet()
        {
            if (!HttpContext.Session.GetString("RoleId").Equals("Admin"))
            {
                TempData["ErrorMessage"] = "You do not have permission to access this page.";
                return RedirectToPage("/Index");
            }

            ViewData["RoleId"] = new SelectList(await _roleService.GetAll(), "Id", "RoleName");
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        [BindProperty(SupportsGet = true)]
        public int RoleId { get; set; }

        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (User == null ||
                string.IsNullOrWhiteSpace(User.FullName) ||
                string.IsNullOrWhiteSpace(User.PhoneNumber) ||
                string.IsNullOrWhiteSpace(User.Email) ||
                string.IsNullOrWhiteSpace(User.Password) ||
                string.IsNullOrWhiteSpace(User.Address) ||
                string.IsNullOrWhiteSpace(User.Description) ||
                User.Status == 0)
            {
                ModelState.AddModelError(string.Empty, "Please fill in all required fields.");
                ViewData["RoleId"] = new SelectList(await _roleService.GetAll(), "Id", "RoleName");
                return Page();
            }

            if (!IsValidEmail(User.Email))
            {
                ModelState.AddModelError(string.Empty, "Invalid email format.");
                ViewData["RoleId"] = new SelectList(await _roleService.GetAll(), "Id", "RoleName");
                return Page();
            }

            if (!IsValidPhone(User.PhoneNumber))
            {
                ModelState.AddModelError(string.Empty, "Invalid phone number format.");
                ViewData["RoleId"] = new SelectList(await _roleService.GetAll(), "Id", "RoleName");
                return Page();
            }
            User.RoleId = RoleId;

            _userService.Add(User);

            return RedirectToPage("/Admin/UserManager/Index");
        }
        private bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }

            foreach (char c in phone)
            {
                if (!char.IsDigit(c) && c != '+' && c != '(' && c != ')' && c != '-' && c != ' ')
                {
                    return false;
                }
            }

            int digitCount = 0;
            foreach (char c in phone)
            {
                if (char.IsDigit(c))
                {
                    digitCount++;
                }
            }

            if (digitCount < 10)
            {
                return false;
            }

            return true;
        }
    }
}
