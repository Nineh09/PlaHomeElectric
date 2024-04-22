using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public partial class User
    {
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
