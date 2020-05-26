using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Entities
{
    public class Person : EntityBase
    {
        [NotMapped]
        public string Name => $"{FirstName} {LastName}";

        [DataMember]
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required.")]
        [StringLength(255, ErrorMessage = "First name exceeds {1} characters.")]
        public string FirstName { get; set; }

        [DataMember]
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required.")]
        [StringLength(255, ErrorMessage = "Last name exceeds {1} characters.")]
        public string LastName { get; set; }

        /// <summary>
        /// Unique constraint - enforced in the Fluent Api.
        /// </summary>
        [DataMember]
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        [StringLength(255, ErrorMessage = "Email must be within {2} to {1} characters long.", MinimumLength = 7)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email requires a valid email address.")]
        public string Email { get; set; }
    }
}
