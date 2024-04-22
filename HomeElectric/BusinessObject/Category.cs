using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
