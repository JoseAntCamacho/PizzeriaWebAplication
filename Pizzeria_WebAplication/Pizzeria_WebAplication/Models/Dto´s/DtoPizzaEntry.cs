using BackendPizzeria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendPizzeria.Dtos
{
    public class DtoPizzaEntry : IDtoPizzaEntry
    {
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        

        public DtoPizzaEntry(string name, byte[] picture, ICollection<Ingredient> ingredients 
                        )
        {
            Name = name;
            Picture = picture;
            Ingredients = ingredients;
        }

        public Pizza ConvertToPizzaEntry()
        {
            return new Pizza(this.Name, this.Picture, this.Ingredients);
        }        
    }
}