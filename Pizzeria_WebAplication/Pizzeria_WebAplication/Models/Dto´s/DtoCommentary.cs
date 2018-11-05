﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendPizzeria.Domain;

namespace BackendPizzeria.Dtos
{
    public class DtoCommentary : IDtoCommentary
    {
        public string Text { get; set;}
        public byte Punctuation { get; set; }
        public DateTime DateTime { get; set; }
        public string User { get; set; }
        public int PizzaId { get; set; }

        
        public DtoCommentary(string text, byte punctuation, DateTime dateTime, string user, int pizzaId)
        {
            Text = text;
            Punctuation = punctuation;
            DateTime = dateTime;
            User = user;
            PizzaId = pizzaId;
        }
        
        public Commentary ConvertToCommentaryEntry()
        {
            return new Commentary(this.Text, this.Punctuation, this.DateTime, this.User, this.PizzaId);
        }
    }
}