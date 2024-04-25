using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeElectric.Pages.Staff.ProductManager
{
    public class IndexModel : PageModel
    {
        public IProductService productService;
        private ICategoryService _categoryService;

        public IndexModel(IProductService productService, ICategoryService categoryService)
        {

            this.productService = productService;
            _categoryService = categoryService;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {

            ViewData["CategoryId"] = new SelectList(await _categoryService.GetAll(), "Id", "Id");
            var listPro = await productService.GetAll();
            if (listPro != null)
            {
                Product = listPro;
            }
            return Page();
        }
    }
}
