using System;
using System.Collections.Generic;

namespace Pizza_API.Models
{
    public partial class OrderSide
    {
        public int SideId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Side Side { get; set; }
    }
}
