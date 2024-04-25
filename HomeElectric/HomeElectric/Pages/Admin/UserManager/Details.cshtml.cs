using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interface;

namespace HomeElectric.Pages.Admin.UserManager
{
    public class DetailsModel : PageModel
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public DetailsModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public User User { get; set; } = default!;
        public string RoleName { get; set; } = "";

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!HttpContext.Session.GetString("RoleId").Equals("Admin"))
            {
                TempData["ErrorMessage"] = "You do not have permission to access this page.";
                return RedirectToPage("/Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            User = await _userService.GetById((int)id);

            if (User == null)
            {
                return NotFound();
            }

            if (User.RoleId != null)
            {
                Role role = await _roleService.GetById(User.RoleId.Value);
                if (role != null)
                {
                    RoleName = role.RoleName;
                }
            }

            return Page();
        }

    }
}
