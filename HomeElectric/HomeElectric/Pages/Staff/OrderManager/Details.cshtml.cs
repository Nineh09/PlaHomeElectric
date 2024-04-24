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
using Service.Implement;
using Microsoft.CodeAnalysis.CSharp;

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
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Order = await orderService.GetById((int)id);
            if (Order == null)
            {
                return NotFound();
            }

            OrderDetail? orderDetail = await orderDetailService.GetById(Order.Id);
            OrderDetails.Add(orderDetail);
            
            return Page();
        }
    }
}
