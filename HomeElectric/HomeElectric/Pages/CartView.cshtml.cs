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
            }
            else
            {
                return Page();
            }
            return Page();
        }
		public async Task<IActionResult> OnPostAsync(string action, int productQuantity, int productId)
		{
            return RedirectToPage();
		}
	}
}
