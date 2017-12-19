using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Class APICredentials.
    /// </summary>
    public class ApiCredentials
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>The signature.</value>
        public string Signature { get; set; }

        /// <summary>
        /// Gets from request headers.
        /// </summary>
        /// <param name="requestHeaders">The request headers.</param>
        /// <returns>API Credentials.</returns>
        public static ApiCredentials GetFromRequestHeaders(HttpRequestHeaders requestHeaders)
        {
            // this could/should be another interface for testing purposes
            var authenticationHeader = requestHeaders.Authorization;
            if (authenticationHeader.Scheme != Configuration.AuthenticationScheme)
            {
                return null;
            }

            if (!requestHeaders.Contains(Configuration.UsernameHeader))
            {
                return null;
            }

            var username = requestHeaders.GetValues(Configuration.UsernameHeader).FirstOrDefault();
            if (username == null)
            {
                return null;
            }

            var decodedBytes = Convert.FromBase64String(authenticationHeader.Parameter);
            var signature = Encoding.UTF8.GetString(decodedBytes);
            return new ApiCredentials()
            {
                Signature = signature,
                Username = username
            };
        }

        /// <summary>
        /// To the authentication header.
        /// </summary>
        /// <returns>AuthenticationHeader Value.</returns>
        public AuthenticationHeaderValue ToAuthenticationHeader()
        {
            var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(this.Signature));
            return new AuthenticationHeaderValue(Configuration.AuthenticationScheme, encoded);
        }
    }
}
