using Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //  TODO:COMPROBAR QUE LOS INGREDIENTES EXISTEN Y QUE TIENE INGREDIENTES

            var ingredientes = ValidaIngredientes(data);
           
            var pizza = Pizza.Create(data,ingredientes);
            if (!pizza.IsValid())
            {
                throw new Exception("No se ha podido añadir la pizza porque no es válida la entidad");
            }            
            var response = _pizzaContext.Pizzas.Add(pizza);
            _pizzaContext.SaveChanges();
            _pizzaContext.Dispose();
            return response;  
        }

        private List<Ingredient> ValidaIngredientes(DtoPizza data)
        {
            if (data.Ingredients.Count() == 0)
            {
                throw new Exception("No se ha encontrado ningún ingrediente");
            }
            var ingredientes = new List<Ingredient>();
            foreach (var item in data.Ingredients)
            {
                var result = _pizzaContext.Ingredients.Find(item);
                if (result == null)
                {
                    throw new Exception("Not Found Item");
                }
                ingredientes.Add(result);
            }
            return ingredientes;
        }

    }
}
