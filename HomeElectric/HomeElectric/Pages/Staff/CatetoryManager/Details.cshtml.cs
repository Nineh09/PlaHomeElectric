using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interface;

namespace HomeElectric.Pages.Staff.CatetoryManager
{
    public class DetailsModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public Category Category { get; set; }

        public DetailsModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!HttpContext.Session.GetString("RoleId").Equals("Staff"))
            {
                TempData["ErrorMessage"] = "You do not have permission to access this page.";
                return RedirectToPage("/Index");
            }
            if (id == null)
            {
                return NotFound();
            }

            Category = await _categoryService.GetById(id.Value);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
