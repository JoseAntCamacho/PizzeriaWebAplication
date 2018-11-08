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
        public IDbSet<Pizza> Pizzas { get; set; }
        public IDbSet<Ingredient> Ingredients { get; set; }
        public IDbSet<Commentary> Commentaries { get; set; }
        public IDbSet<FormItem> FormItems { get; set; }

        /*IDbSet<Pizza> IPizzaContext.Pizzas => this.Pizza;
        IDbSet<Ingredient> IPizzaContext.Ingredients => this.Ingredient;
        IDbSet<Commentary> IPizzaContext.Commentaries => this.Commentary;*/

        int IUOW.SaveChanges()
        {
            return this.SaveChanges();
        }

        public PizzaContext() : base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commentary>()
                .HasRequired<Pizza>(s => s.Pizza)
                .WithMany(g => g.Commentaries)
                .HasForeignKey<int>(s => s.PizzaId);

        }
    }
}
