using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class DtoPizza
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public byte[] Picture { get; set; }
        [Required]
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
