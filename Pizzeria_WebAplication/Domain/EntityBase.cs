using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;


namespace Domain
{
    public class EntityBase : IValidatableObject
    {
        
        public virtual bool IsValid()
        {
            var context= new ValidationContext(this, null, null);
            var result= new List<ValidationResult>();
            return Validator.TryValidateObject(this, context, result);
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //var context = new ValidationContext(this, null, null);
            var result = new List<ValidationResult>()
            {
                new ValidationResult("Aquí no hay nada")
            };
            //Validator.TryValidateObject(this, validationContext, result);
            return result;

            //Esto creo que se autollama a sí mismo.
        }

    }
}
