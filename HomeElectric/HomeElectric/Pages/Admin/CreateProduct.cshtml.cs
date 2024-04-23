using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;

namespace HomeElectric.Pages.Admin
{
    public class CreateProductModel : PageModel
    {
        private readonly YourDbContext _context;

        public CreateProductModel(YourDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            _context.SaveChanges();

            return RedirectToPage("/Admin/ProductList");
        }
    }
}