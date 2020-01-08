//s15885

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizza_API.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderPizza = new HashSet<OrderPizza>();
            PizzaIngredient = new HashSet<PizzaIngredient>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        public decimal Price { get; set; }
        public int MenuId { get; set; }
        public string Crust { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Name { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual ICollection<PizzaIngredient> PizzaIngredient { get; set; }
    }
}
