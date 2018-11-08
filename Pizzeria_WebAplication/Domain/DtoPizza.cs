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
        public DtoPizza()
        {
            Ingredients = new HashSet<int>();
        }

        public string Name { get; set; }   
        public byte[] Picture { get; set; }
        public ICollection<int> Ingredients { get; set; }
        public FormItem FormItems { get; set; }
    }
}
