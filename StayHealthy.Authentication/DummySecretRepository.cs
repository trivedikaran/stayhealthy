using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Class DummySecretRepository.
    /// </summary>
    public class DummySecretRepository : ISecretRepository
    {
        /// <summary>
        /// The _user passwords
        /// </summary>
        private readonly IDictionary<string, string> userPasswords
            = new Dictionary<string, string>() 
            { 
            { "username", "password" },
            { "wipuser", "password" }, 
            { "quiveruser", "password" },
            { "pdsuser", "password" },
            { "biztalkuser", "password" } 
            };

        /// <summary>
        /// Gets the secret for user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns> return String. </returns>
        public string GetSecretForUser(string username)
        {
            if (!this.userPasswords.ContainsKey(username))
            {
                return null;
            }

            var userPassword = this.userPasswords[username];
            var hashed = this.ComputeHash(userPassword, new SHA1CryptoServiceProvider());
            return hashed;
        }

        /// <summary>
        /// Computes the hash.
        /// </summary>
        /// <param name="inputData">The input data.</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>return String.</returns>
        private string ComputeHash(string inputData, HashAlgorithm algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
            byte[] hashed = algorithm.ComputeHash(inputBytes);
            return Convert.ToBase64String(hashed);
        }
    }
}
