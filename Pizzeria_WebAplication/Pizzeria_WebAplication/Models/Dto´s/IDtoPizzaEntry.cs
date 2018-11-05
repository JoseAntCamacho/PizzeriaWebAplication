using BackendPizzeria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPizzeria.Dtos
{
    public interface IDtoPizzaEntry
    {
        Pizza ConvertToPizzaEntry();
    }
}