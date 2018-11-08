using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DtoPizza
    {
        public string Name { get; set; }   
        public byte[] Picture { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
