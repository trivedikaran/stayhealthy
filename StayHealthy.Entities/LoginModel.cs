using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StayHealthy.Entities
{
    public class LoginModel : IValidatableObject
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string RegistrationPassword { get; set; }
        public int DateofBirthYear { get; set; }
        public int DateofBirthMonth { get; set; }
        public int DateofBirthDay { get; set; }
        [Required]
        public int GenderType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                yield return new ValidationResult("");
        }
    }
}
