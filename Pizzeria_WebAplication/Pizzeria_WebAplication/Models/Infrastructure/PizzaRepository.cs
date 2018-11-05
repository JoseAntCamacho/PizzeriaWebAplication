using BackendPizzeria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BackendPizzeria.Dtos;

namespace BackendPizzeria.Infrastructure
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly IPizzaContext _context;

        public PizzaRepository(IPizzaContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context)); 
        }

        public void Create(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _context.Pizzas.AsEnumerable<Pizza>();            
        }

        public Pizza GetById(int id)
        {
            return _context.Pizzas.Find(id);
        }

        public void UpdateCommentary(int idPizza, Commentary commentary)
        {
            _context.Pizzas.Find(idPizza).Commentaries.Add(commentary);
        }
    }
}