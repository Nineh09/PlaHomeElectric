using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Service.Interface;

namespace HomeElectric.Pages.Admin.UserManager
{
    public class CreateModel : PageModel
    {
        private IUserService _userService;

        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userService.Add(User);

            return RedirectToPage("/Admin/UserManager/Index");
        }
    }
}
