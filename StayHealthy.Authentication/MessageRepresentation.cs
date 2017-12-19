using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Class MessageRepresentation.
    /// </summary>
    public class MessageRepresentation
    {
        /// <summary>
        /// Gets or sets the representation.
        /// </summary>
        /// <value>The representation.</value>
        public string Representation { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }
    }
}
