using BackendPizzeria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendPizzeria.Dtos
{
    public class DtoPizzaExit
    {
             
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Commentary> Commentaries { get; set; }

        public DtoPizzaExit(string name, byte[] picture, ICollection<Ingredient> ingredients,
                        ICollection<Commentary> commentaries)
        {
            Name = name;
            Picture = picture;
            Ingredients = ingredients;
            Commentaries = commentaries;
        }

        public IEnumerable<DtoPizzaExit> GetAll(IEnumerable<Pizza> pizzas)
        {
            IEnumerable<DtoPizzaExit> result = pizzas.Select(p => new DtoPizzaExit(p.Name,
                p.Picture, p.Ingredients, p.Commentaries));

            return result;
                
                
        }
    }
}