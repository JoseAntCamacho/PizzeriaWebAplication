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

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; } 
         
        public ICollection<Pizza> Pizzas { get; set; }
    }
}