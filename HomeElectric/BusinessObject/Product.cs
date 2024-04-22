using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Product
    {
        public Product()
        {
            Feedbacks = new HashSet<Feedback>();
            Images = new HashSet<Image>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
