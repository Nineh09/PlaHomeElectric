using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            Feedbacks = new HashSet<Feedback>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
