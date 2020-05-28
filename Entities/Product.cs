using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Entities
{
    public class Product : EntityBase
    {
        [DataMember]
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
        [StringLength(150, ErrorMessage = "Name exceeds {1} characters.")]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "Code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code is required.")]
        [StringLength(255, ErrorMessage = "Code exceeds {1} characters.")]
        public string Code { get; set; }

        [DataMember]
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required.")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
    }
}
