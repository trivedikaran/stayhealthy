using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Entities
{
    public class UserRegistrationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int DateofBirthYear { get; set; }
        public int DateofBirthMonth { get; set; }
        public int DateofBirthDay { get; set; }
        public int GenderType { get; set; }
    }
}
