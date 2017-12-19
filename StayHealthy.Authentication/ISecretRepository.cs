using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Interface ISecretRepository
    /// </summary>
    public interface ISecretRepository
    {
        /// <summary>
        /// Gets the secret for user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>return String.</returns>
        string GetSecretForUser(string username);
    }
}
