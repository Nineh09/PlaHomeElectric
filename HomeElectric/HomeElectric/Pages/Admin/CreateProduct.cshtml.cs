using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Service.Implement;
using Service.Interface;

namespace HomeElectric.Pages.Admin
{
    public class CreateProductModel : PageModel
    {
        private readonly IProductService productService;

        public CreateProductModel(IProductService productService)
        {
            this.productService = productService;
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
            productService.Add(Product);

            return RedirectToPage("/Admin/ProductList");
        }
    }
}