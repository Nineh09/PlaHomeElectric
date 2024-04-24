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
    public class IndexModel : PageModel
    {
        private IUserService _userService;

        public IndexModel(IUserService cusService)
        {
            _userService = cusService;
        }

        public IList<User> User { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var listCus = await _userService.GetAll();
            if (listCus != null)
            {
                User = listCus;
            }
            return Page();
        }
    }
}
