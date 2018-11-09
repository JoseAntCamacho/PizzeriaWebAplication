using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public class FormItem: EntityBase
    {
        public FormItem() { }

        [Key,ForeignKey("Pizza")]
        public int PizzaFormId { get; set; }
        public string name { get; set; }
        public byte[] data { get; set; }
        public string fileName { get; set; }
        public string mediaType { get; set; }
        public string value { get { return Encoding.Default.GetString(data); } }
        public bool isAFileUpload { get { return !String.IsNullOrEmpty(fileName); } }

        public virtual Pizza Pizza { get; set; }
        
        private readonly List<string> Extensions = new List<string>
        {
            "image/jpeg",
            "image/jpg",
            "image/gif",
            "image/png",
            "image/bmp",
            "image/webp"
        };

        public override bool IsValid()
        {
            var valid = base.IsValid();
            if (!Extensions.Contains(mediaType))
            {
                this.Errors.Add(new ValidationResult("Extension no encontrada"));
                valid = false;
            }
            return valid;
        }
    }
}
