using System;
using System.Collections.Generic;

namespace Pizza_API.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderPizza = new HashSet<OrderPizza>();
            OrderSide = new HashSet<OrderSide>();
        }

        public int Id { get; set; }
        public int OrderNr { get; set; }
        public int ClientId { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public int AdminId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentId { get; set; }
        public string DealCode { get; set; }
        public string Delivery { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Client Client { get; set; }
        public virtual Deal DealCodeNavigation { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual ICollection<OrderSide> OrderSide { get; set; }
    }
}
