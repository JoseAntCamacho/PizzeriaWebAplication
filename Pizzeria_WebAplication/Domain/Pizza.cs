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

        public Pizza()
        {
            this.Ingredients = new HashSet<Ingredient>();
            this.Commentaries = new HashSet<Commentary>();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] Picture { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Commentary> Commentaries { get; set; }
        public virtual FormItem FormItem { get; set; }



        public decimal Price()
        {
            decimal profit = Decimal.Parse(ConfigurationManager.AppSettings["Profit"]);
            return this.Ingredients.Sum(c => c.Price) + profit;
        }

        public static Pizza Create (DtoPizza dato, IEnumerable<Ingredient> ingredients)
        {
            var pizza = new Pizza()
            {
                Name = dato.Name,
                Picture = dato.Picture,
                Ingredients = ingredients.ToList()               
            };
            return pizza;
        }

        public override bool IsValid()
        {
            var valid = base.IsValid();
            if (this.Ingredients.Count==0)
            {
                this.Errors.Add(new ValidationResult("No hay ingredientes en la pizza"));
                valid = false;
            }
            return valid;
        }
    }
}
