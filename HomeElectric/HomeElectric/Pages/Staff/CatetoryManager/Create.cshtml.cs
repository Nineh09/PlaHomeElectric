using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Service.Interface;

namespace HomeElectric.Pages.Staff.CatetoryManager
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public CreateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult OnGet()
        {
            if (!HttpContext.Session.GetString("RoleId").Equals("Staff"))
            {
                TempData["ErrorMessage"] = "You do not have permission to access this page.";
                return RedirectToPage("/Index");
            }
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = new Category();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Category == null)
            {
                return Page();
            }

            try
            {
                var existingCategory = await _categoryService.GetCateName(Category.CategoryName);
                if (existingCategory != null)
                {
                    ModelState.AddModelError("", "Category already exists.");
                    return Page();
                }

                Category.Status = 1;
                Category.CreationDate = DateTime.Now;
                Category.ModificationDate = DateTime.Now;
                Category.IsDeleted = false;

                await _categoryService.Add(Category);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred while creating the category: {ex.Message}");
                return Page();
            }
        }
    }
}
