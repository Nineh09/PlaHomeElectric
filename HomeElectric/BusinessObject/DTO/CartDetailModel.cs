﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CartDetailModel
    {
        public int ProductId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
