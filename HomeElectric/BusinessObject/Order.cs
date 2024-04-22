using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int? Status { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
