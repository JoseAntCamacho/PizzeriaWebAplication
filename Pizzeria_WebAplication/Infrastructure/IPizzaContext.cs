using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IPizzaContext : IUOW
    {
        DbSet<Pizza> Pizza{get; set;}
        DbSet<Ingredient> Ingredient{get; set;}
        DbSet<Commentary> Commentary{get; set;}

    }
}