using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Interface;

namespace HomeElectric.Pages.Staff.OrderManager
{
	public class EditModel : PageModel
    {
		public IOrderService orderService;
		public IOrderDetailService orderDetailService;
        public IUserService userService;

		public EditModel(IOrderService orderService, IOrderDetailService orderDetailService, IUserService userService)
		{
			this.orderService = orderService;
			this.orderDetailService = orderDetailService;
            this.userService = userService;
		}

		[BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var order = await orderService.GetById((int)id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;
            ViewData["UserId"] = new SelectList(await userService.GetAll(), "Id", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                orderService.Update(Order);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return RedirectToPage("./Index");
        }

        
    }
}
