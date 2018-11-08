namespace Infrastructure.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.PizzaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Infrastructure.PizzaContext context)
        {
            context.Ingredients.AddOrUpdate(c => c.Id,
                new Ingredient() { Name = "Tomate", Price = 0.5M },
                new Ingredient() { Name = "Queso", Price = 0.20M },
                new Ingredient() { Name = "Oregano", Price = 0.10M },
                new Ingredient() { Name = "Masa", Price = 1 }
           );
        }
    }
}
