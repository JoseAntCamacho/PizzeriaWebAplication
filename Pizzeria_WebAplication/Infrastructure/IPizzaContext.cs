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
        IDbSet<Pizza> Pizzas{get;}
        IDbSet<Ingredient> Ingredients{ get; }
        IDbSet<Commentary> Commentaries{ get; }
        IDbSet<FormItem> FormItems { get; }
    }
}