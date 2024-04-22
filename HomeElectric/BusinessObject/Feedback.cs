using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int? OrderDetailId { get; set; }
        public string? Comment { get; set; }
        public int? Rate { get; set; }
        public DateTime? Date { get; set; }

        public virtual OrderDetail? OrderDetail { get; set; }
        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
