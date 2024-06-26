using BusinessObject;
using BusinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Protocol;
using Service.Interface;
using Stripe;

namespace HomeElectric.Pages.Customer
{
	public class CreateOrderModel : PageModel
	{
		private IOrderService orderService;
		private IUserService userService;
		private IOrderDetailService orderDetailService;
		public CreateOrderModel(IOrderService orderService, IUserService userService, IOrderDetailService orderDetailService)
		{
			this.orderService = orderService;
			this.userService = userService;
			this.orderDetailService = orderDetailService;
		}
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			var cartSession = HttpContext.Session.GetString("cartSession");
			var cartExisted = JsonConvert.DeserializeObject<CartModel>(cartSession);
			var userId = HttpContext.Session.GetInt32("UserId");
			//userId = "1";
			if (userId != null) { var user = userService.GetById(userId.Value); }
			var order = new Order
			{
				TotalPrice = cartExisted.TotalPrice,
				Status = 1,
				UserId = userId,
				CreationDate = DateTime.Now,
			};
			orderService.Add(order);
			foreach (var cartItem in cartExisted.CartList)
			{
				var orderDetail = new OrderDetail
				{
					OrderId = order.Id,
					ProductId = cartItem.Product.Id,
					Quantity = cartItem.Quantity,
				};
				orderDetailService.Add(orderDetail);
			}
			cartExisted.CartList.Clear();
			cartExisted.TotalPrice = 0;
			HttpContext.Session.SetString("cartSession", cartExisted.ToJson());
			return RedirectToPage("/CartView");
		}
	}
}
