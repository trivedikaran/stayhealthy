using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Interface IBuildMessageRepresentation
    /// </summary>
    public interface IBuildMessageRepresentation
    {
        /// <summary>
        /// Builds the request representation.
        /// </summary>
        /// <param name="requestMessage">The request message.</param>
        /// <returns>return String.</returns>
        string BuildRequestRepresentation(HttpRequestMessage requestMessage);
    }
}
