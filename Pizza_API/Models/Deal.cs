using System;
using System.Collections.Generic;

namespace Pizza_API.Models
{
    public partial class Deal
    {
        public Deal()
        {
            Order = new HashSet<Order>();
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
