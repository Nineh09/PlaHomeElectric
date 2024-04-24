using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;

namespace HomeElectric.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        public async void OnGet()
        {
            Products = await _productService.GetAll();
            Categories = await _categoryService.GetAll();
        }
    }
}
