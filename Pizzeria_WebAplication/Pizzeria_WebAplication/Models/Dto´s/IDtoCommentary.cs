using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendPizzeria.Domain;

namespace BackendPizzeria.Dtos
{
    public interface IDtoCommentary
    {
        Commentary ConvertToCommentaryEntry();
    }
}