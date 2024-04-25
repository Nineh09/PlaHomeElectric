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
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public DeleteModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public Category Category { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryToDelete = await _categoryService.GetById(id.Value);

            if (categoryToDelete == null)
            {
                return NotFound();
            }

            await _categoryService.Delete(categoryToDelete);

            return RedirectToPage("./Index");
        }
    }
}