using System;
using System.Collections.Generic;

namespace Pizza_API.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
