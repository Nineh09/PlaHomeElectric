using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interface;

namespace HomeElectric.Pages.Staff.OrderManager
{
    public class IndexModel : PageModel
    {
        public IOrderService orderService;
      

        public IndexModel( IOrderService orderService)
        {

            this.orderService = orderService;
        }
        public IList<Order> Order { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var listCus = await orderService.GetAll();
            if (listCus != null)
            {
                Order = listCus;
            }
            return Page();
        }
    }
}
