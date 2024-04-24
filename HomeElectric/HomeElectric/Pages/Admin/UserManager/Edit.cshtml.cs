using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interface;

namespace HomeElectric.Pages.Admin.UserManager
{
    public class EditModel : PageModel
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public EditModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["RoleId"] = new SelectList(await _roleService.GetAll(), "Id", "RoleName");
            User = await _userService.GetById((int)id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _userService.Update(User);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToPage("/Admin/UserManager/Index");
        }
    }
}
