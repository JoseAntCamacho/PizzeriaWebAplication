using Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Application
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaContext _pizzaContext;

        public PizzaService(IPizzaContext pizzaContext)
        {
            _pizzaContext = pizzaContext;
        }

        public Pizza Add(DtoPizza data)
        {
            var ingredientes = GetIngredients(data.Ingredients);

            var pizza = Pizza.Create(data,ingredientes);

            if (!pizza.IsValid())
            {
                throw new CustomException(pizza.Errors);
            }            
            var response = _pizzaContext.Pizzas.Add(pizza);
            _pizzaContext.SaveChanges();
            _pizzaContext.Dispose();
            return response;  
        }

        private IEnumerable<Ingredient> GetIngredients(IEnumerable<int> ingredients)
        {
            //método que devuelve todos los ingredientes que están en la lista de int del Dto.            
            return _pizzaContext.Ingredients.Where(c=> ingredients.Contains(c.Id));
        }

        public byte[] GetImage (int id)
        {
            if(null == _pizzaContext.Pizzas.Find(id))
            {
                throw new ArgumentNullException("La pizza no se ha encontrado");
            }
            return _pizzaContext.Pizzas.Find(id).Picture;
        }

    }
}
