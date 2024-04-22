using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? OrderDetailId { get; set; }
        public string? PaymentName { get; set; }

        public virtual OrderDetail? OrderDetail { get; set; }
    }
}
