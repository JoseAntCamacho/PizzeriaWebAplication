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
        private IPizzaContext _pizzaContext;

        public Pizza Add(DtoPizza data)
        {
            var pizza = Pizza.Create(data);
            if (!pizza.IsValid())
            {
                throw new Exception("No se ha podido añadir la pizza porque no es válida la entidad");
            }            
            var response = _pizzaContext.Pizzas.Add(pizza);
            _pizzaContext.SaveChanges();
            return response;  
        }

    }
}
