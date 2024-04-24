using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interface;
using System.Collections.Immutable;

namespace HomeElectric.Pages.Staff.OrderManager
{
    public class DetailsModel : PageModel
    {
		public IOrderService orderService;
		public IOrderDetailService orderDetailService;

		public DetailsModel(IOrderDetailService orderDetailService, IOrderService orderService)
		{
			this.orderDetailService = orderDetailService;
            this.orderService = orderService;   
		}

		public Order Order { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var order = await orderService.GetById((int)id);
            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            return Page();
        }
    }
}
