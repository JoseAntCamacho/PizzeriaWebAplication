using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;

namespace Infrastructure
{
    public class PizzaContext : DbContext, IPizzaContext
    {
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Commentary> Commentary { get; set; }

        IDbSet<Pizza> IPizzaContext.Pizza => this.Pizza;
        IDbSet<Ingredient> IPizzaContext.Ingredient => this.Ingredient;
        IDbSet<Commentary> IPizzaContext.Commentary => this.Commentary;

        int IUOW.SaveChanges()
        {
            return this.SaveChanges();
        }
    }
}
