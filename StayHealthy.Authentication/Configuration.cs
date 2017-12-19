using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Class Configuration.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The username header
        /// </summary>
        public const string UsernameHeader = "X-ApiAuth-Username";

        /// <summary>
        /// The authentication scheme
        /// </summary>
        public const string AuthenticationScheme = "ApiAuth";

        /// <summary>
        /// The validity period in minutes
        /// </summary>
        public const int ValidityPeriodInMinutes = 5;

        /// <summary>
        /// The date value header
        /// </summary>
        public const string DateValueHeader = "DateValue";
    }
}
