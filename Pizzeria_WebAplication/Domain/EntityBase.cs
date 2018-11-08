using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;


namespace Domain
{
    public class EntityBase 
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual bool IsValid()
        {
            var context= new ValidationContext(this, null, null);
            var result= new List<ValidationResult>();
            return Validator.TryValidateObject(this, context, result);
        }

    }
}
