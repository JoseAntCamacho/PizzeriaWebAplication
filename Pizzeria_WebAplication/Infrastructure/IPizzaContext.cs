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
        IDbSet<Pizza> Pizza{get;}
        IDbSet<Ingredient> Ingredient{ get; }
        IDbSet<Commentary> Commentary{ get; }
        //Context


    }
}