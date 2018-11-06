namespace Infrastructure.PizzaContextMigrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Infrastructure;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.PizzaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"PizzaContextMigrations";
        }

        protected override void Seed(PizzaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Ingredient[] listaInicial = new Ingredient[]
            {
                new Ingredient { Name = "TomateFrito", Price = 0.7M},
                new Ingredient { Name = "Queso", Price = 1.05M},
                new Ingredient { Name = "Oregano", Price = 0.2M},
                new Ingredient { Name = "Masa de pizza", Price = 1.5M}
            };
            if (context.Ingredients == null)
            {
                context.Ingredients.AddOrUpdate(listaInicial);
            }
        }
    }
}
