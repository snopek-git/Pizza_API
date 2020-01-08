using System;
using System.Collections.Generic;

namespace Pizza_API.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            PizzaIngredient = new HashSet<PizzaIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PizzaIngredient> PizzaIngredient { get; set; }
    }
}
