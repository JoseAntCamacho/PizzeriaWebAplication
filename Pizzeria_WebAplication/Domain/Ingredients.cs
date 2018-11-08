using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Ingredient : EntityBase
    {
        public Ingredient()
        {
            this.Pizzas = new HashSet<Pizza>();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; } 
         
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}