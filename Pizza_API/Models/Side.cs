using System;
using System.Collections.Generic;

namespace Pizza_API.Models
{
    public partial class Side
    {
        public Side()
        {
            OrderSide = new HashSet<OrderSide>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual ICollection<OrderSide> OrderSide { get; set; }
    }
}
