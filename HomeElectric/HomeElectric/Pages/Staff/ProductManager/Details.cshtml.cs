using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interface;

namespace HomeElectric.Pages.Staff.ProductManager
{
    public class DetailsModel : PageModel
    {
        public IProductService _productService;

        public DetailsModel(IProductService productService)
        {

            _productService = productService;
        }

        public Product Product { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productService.GetById(id.Value);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
