using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IPizzaContext : IUOW
    {
        IDbSet<Pizza> Pizza{get; set;}
        IDbSet<Ingredient> Ingredient{get; set;}
        IDbSet<Commentary> Commentary{get; set;}

    }
}