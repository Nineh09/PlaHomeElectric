using BusinessObject.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Protocol;
using Service.Interface;

namespace HomeElectric.Pages.Customer
{
    public class AddToCartModel : PageModel
    {
        private IProductService productService;
        private IUserService userService;
        public AddToCartModel(IProductService productService, IUserService userService)
        {
            this.productService = productService;
            this.userService = userService;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            string user = HttpContext.Session.GetString("RoleId");
            //if (user == null)
            //{
            //    return RedirectToPage("/Login");
            //}
            //if (user != null && user != "CUSTOMER")
            //{
            //    return RedirectToPage("/Login");
            //}
            var product = await productService.GetById((int)id);
            if (product == null)
            {
                return NotFound();
            }

            var cartSession = HttpContext.Session.GetString("cartSession");
            if (cartSession == null)
            {
                //var customerSession = HttpContext.Session.GetString("customerSession");
                //if (customerSession == null)
                //{
                //    return BadRequest();
                //}
                //var customer = await userService.GetById(Int32.Parse(customerSession));
                var newCart = new CartModel
                {
                    //User = customer,
                    //UserId = Int32.Parse(customerSession),
                    CartList = new List<CartDetailModel>(),
                    TotalPrice = 0,
                };
                var itemInCart = new CartDetailModel
                {
                    Product = product,
                    ProductId = (int)id,
                    Price = product.Price,
                    Quantity = 1
                };
                newCart.CartList.Add(itemInCart);
                newCart.TotalPrice += product.Price;
                HttpContext.Session.SetString("cartSession", newCart.ToJson());
            }
            else
            {
                var cartExisted = JsonConvert.DeserializeObject<CartModel>(cartSession);
                var productExistedInCart = cartExisted.CartList.Where(x => x.ProductId != null && x.ProductId == product.Id).FirstOrDefault();
                if (productExistedInCart != null)
                {
                    cartExisted.CartList.Remove(productExistedInCart);
                    productExistedInCart.Quantity++;
                    cartExisted.TotalPrice += productExistedInCart.Price;
                    cartExisted.CartList.Add(productExistedInCart);
                    HttpContext.Session.SetString("cartSession", cartExisted.ToJson());
                }
                else
                {
                    var itemInCart = new CartDetailModel
                    {
                        Product = product,
                        ProductId = (int)id,
                        Price = product.Price,
                        Quantity = 1
                    };
                    cartExisted.TotalPrice += product.Price;
                    cartExisted.CartList.Add(itemInCart);
                    HttpContext.Session.SetString("cartSession", cartExisted.ToJson());
                }
            }
            return RedirectToPage("/ProductPage");
        }
    }
}
