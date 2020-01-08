using System;
using System.Collections.Generic;

namespace Pizza_API.Models
{
    public partial class PizzaIngredient
    {
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
