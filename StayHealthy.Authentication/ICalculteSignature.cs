using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Interface ICALCULTESignature
    /// </summary>
    public interface ICalculteSignature
    {
        /// <summary>
        /// Signatures the specified secret.
        /// </summary>
        /// <param name="secret">The secret.</param>
        /// <param name="value">The value.</param>
        /// <returns>return String.</returns>
        string Signature(string secret, string value);
    }
}
