using System;
using System.Collections.Generic;

namespace Pizza_API.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Pizza = new HashSet<Pizza>();
            Side = new HashSet<Side>();
        }

        public int Id { get; set; }
        public string Season { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
        public virtual ICollection<Side> Side { get; set; }
    }
}
