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
        private IPizzaContext pizzaContext;

        public Pizza Add(DtoPizza data)
        {
            var pizza = Pizza.Create(data);
            if (!pizza.IsValid())
            {
                throw new Exception("No se ha podido añadir la pizza porque no es válida la entidad");
            }            
            var response = pizzaContext.Pizzas.Add(pizza);
            pizzaContext.SaveChanges();
            return response;  
        }

    }
}
