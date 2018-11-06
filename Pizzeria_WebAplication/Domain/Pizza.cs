using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;


namespace Domain
{
    public class Pizza : EntityBase
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] Picture { get; set; }
        
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Commentary> Commentaries { get; set; }

        public decimal Price()
        {
            decimal profit = Decimal.Parse(ConfigurationManager.AppSettings["Profit"]);
            return this.Ingredients.Sum(c => c.Price) + profit;
        }

        public static Pizza Create (DtoPizza dato)
        {
            var pizza = new Pizza()
            {
                Name = dato.Name,
                Picture = dato.Picture,
                Ingredients = dato.Ingredients
            };
            return pizza;
        }
    }
}
