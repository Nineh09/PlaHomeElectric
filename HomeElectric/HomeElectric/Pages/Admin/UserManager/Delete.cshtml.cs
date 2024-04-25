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
    public class DeleteModel : PageModel
    {
        private IUserService _userService;

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!HttpContext.Session.GetString("RoleId").Equals("Admin"))
            {
                TempData["ErrorMessage"] = "You do not have permission to access this page.";
                return RedirectToPage("/Index");
            }

            User = await _userService.GetById((int)id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var user = await _userService.GetById((int)id);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                await _userService.Delete(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToPage("/Admin/UserManager/Index");
        }
    }
}
