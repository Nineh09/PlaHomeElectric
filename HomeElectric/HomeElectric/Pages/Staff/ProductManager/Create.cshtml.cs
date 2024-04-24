using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Service.Interface;

namespace HomeElectric.Pages.Staff.ProductManager
{
    public class CreateModel : PageModel
    {
        private readonly IProductService productService;

        public CreateModel(IProductService productService)
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
