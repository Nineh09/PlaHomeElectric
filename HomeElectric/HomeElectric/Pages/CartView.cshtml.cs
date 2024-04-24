using BusinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeElectric.Pages.Customer
{
    public class CartViewModel : PageModel
    {
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
    }
}
