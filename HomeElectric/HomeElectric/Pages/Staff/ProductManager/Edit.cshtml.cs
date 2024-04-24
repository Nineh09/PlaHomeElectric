using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interface;

namespace HomeElectric.Pages.Staff.ProductManager
{
    public class EditModel : PageModel
    {
        public IProductService _productService;
        private ICategoryService _categoryService;

        public EditModel(IProductService productService, ICategoryService categoryService)
        {

            _productService = productService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["CategoryId"] = new SelectList(await _categoryService.GetAll(), "Id", "CategoryName");
            Product = await _productService.GetById(id.Value);
            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _productService.Update(Product);
            }
            catch
            {
                return BadRequest();
            }

            return RedirectToPage("./Index");
        }
    }
}
