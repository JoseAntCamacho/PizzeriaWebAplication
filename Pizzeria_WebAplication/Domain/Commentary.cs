using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackendPizzeria.Dtos;

namespace Domain
{
    public class Commentary : EntityBase
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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

        public Commentary()
        {

        }

        public Commentary(string text, byte punctuation, DateTime dateTime, string user, int pizzaId)
        {
            Text = text;
            Punctuation = punctuation;
            DateTime = dateTime;
            User = user;
            PizzaId = pizzaId;
        }
    }
}