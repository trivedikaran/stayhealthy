using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Class HMACSignatureCalculator.
    /// </summary>
    public class HmacSignatureCalculator : ICalculteSignature
    {
        /// <summary>
        /// Signatures the specified secret.
        /// </summary>
        /// <param name="secret">The secret.</param>
        /// <param name="value">The value.</param>
        /// <returns>return String.</returns>
        public string Signature(string secret, string value)
        {
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var valueBytes = Encoding.UTF8.GetBytes(value);
            string signature;

            using (var hmac = new HMACSHA256(secretBytes))
            {
                var hash = hmac.ComputeHash(valueBytes);
                signature = Convert.ToBase64String(hash);
            }

            return signature;
        }
    }
}
