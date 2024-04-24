using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CartModel
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public decimal? TotalPrice { get; set; }
        public List<CartDetailModel>? CartList { get; set; }
    }
}
