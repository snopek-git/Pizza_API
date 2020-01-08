using System;
using System.Collections.Generic;

namespace Pizza_API.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int ClientId { get; set; }
        public string Method { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
