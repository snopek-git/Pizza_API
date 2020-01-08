using System;
using System.Collections.Generic;

namespace Pizza_API.Models
{
    public partial class Client
    {
        public Client()
        {
            Order = new HashSet<Order>();
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNr { get; set; }
        public string AddressDetails { get; set; }
        public string City { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
