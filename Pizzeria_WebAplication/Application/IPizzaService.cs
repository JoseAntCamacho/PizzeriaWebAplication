using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IPizzaService
    {
        Pizza Add(DtoPizza dato);
        byte[] GetImageByPizzaId(int id);
        string GetMediaTypeImage(int id);
    }
}
