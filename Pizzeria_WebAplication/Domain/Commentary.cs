using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Commentary : EntityBase
    {

        [Required]
        public string Text { get; set; }
        [Required]
        public byte Punctuation { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string User { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

    }
}