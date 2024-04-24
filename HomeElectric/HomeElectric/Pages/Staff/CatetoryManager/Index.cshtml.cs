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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategoryService _categoryService;

        public List<Category> Categories { get; set; }
        public IList<Category> Category { get; set; } = new List<Category>();

        public IndexModel(ILogger<IndexModel> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public async Task OnGetAsync()
        {
            Categories = await _categoryService.GetAll();
            if (Categories != null && Categories.Count > 0)
            {
                Category = Categories.ToList();
            }
        }
    }

}
