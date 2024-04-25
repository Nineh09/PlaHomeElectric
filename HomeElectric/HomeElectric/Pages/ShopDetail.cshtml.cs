using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;

namespace HomeElectric.Pages
{
    public class ShopDetailModel : PageModel
    {
        private readonly IProductService _productService;
        public Product? product { get; set; }
        public List<Product>? Products { get; set; }
        public ShopDetailModel(IProductService productService) {
            _productService = productService;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();
            product = await _productService.GetById((int)id);
            if (product == null)
                return NotFound();
            Products = await _productService.GetAll();
            return Page();
        }
    }
}
