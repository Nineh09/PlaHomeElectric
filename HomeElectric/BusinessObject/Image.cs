﻿using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class Image
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }

        public virtual Product? Product { get; set; }
    }
}
