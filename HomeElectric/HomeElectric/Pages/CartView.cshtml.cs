using BusinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol;
using Service.Interface;

namespace HomeElectric.Pages
{
    public class CartViewModel : PageModel
    {
		private IProductService productService;
		private IUserService userService;
		public CartViewModel(IProductService productService, IUserService userService)
		{
			this.productService = productService;
			this.userService = userService;
		}
		[BindProperty]
        public CartModel CartModel { get; set; } = default!;
        [BindProperty]
        public IList<CartDetailModel> CartDetail { get; set; } = default!;
        public List<Payment> Payments { get; set; } = default!;
        public IPaymentService _paymentService;
        

		public CartViewModel(IPaymentService paymentService)
		{
			this._paymentService = paymentService;
		}

		public async Task<IActionResult> OnGetAsync()
        {
            //string account = HttpContext.Session.GetString("role");
            //if (account == null)
            //{
            //    return RedirectToPage("/Login");
            //}
            //if (account != null && account != "CUSTOMER")
            //{
            //    return RedirectToPage("/Login");
            //}
            var cartSession = HttpContext.Session.GetString("cartSession");
            if(cartSession != null)
            {
                var cart = JsonConvert.DeserializeObject<CartModel>(cartSession);
                if (cart != null)
                {
                    CartModel = cart;
                    CartModel.CartList = cart.CartList;
                    CartDetail = cart.CartList;
                }
                Payments = await _paymentService.GetAll();
            }
            else
            {
                return Page();
            }
            return Page();
        }
		public async Task<IActionResult> OnPostAsync(int productId)
		{
			var cartSession = HttpContext.Session.GetString("cartSession");
			var cartExisted = JsonConvert.DeserializeObject<CartModel>(cartSession);
			var productExistedInCart = cartExisted.CartList.Where(x => x.ProductId != null && x.ProductId == productId).FirstOrDefault();
			if (productExistedInCart != null)
			{
				cartExisted.CartList.Remove(productExistedInCart);
				cartExisted.TotalPrice -= productExistedInCart.Price*productExistedInCart.Quantity;
				HttpContext.Session.SetString("cartSession", cartExisted.ToJson());
			}
			return RedirectToPage();
		}
	}
}
