using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Class CanonicalRepresentationBuilder.
    /// </summary>
    public class CanonicalRepresentationBuilder : IBuildMessageRepresentation
    {
        /// <summary>
        /// Builds message representation as follows:
        /// HTTP METHOD\n +
        /// Content-MD5\n +
        /// Timestamp\n +
        /// Username\n +
        /// Request URI
        /// </summary>
        /// <param name="requestMessage">The request message.</param>
        /// <returns>return String.</returns>
        public string BuildRequestRepresentation(HttpRequestMessage requestMessage)
        {
            bool valid = this.IsRequestValid(requestMessage);
            if (!valid)
            {
                return null;
            }

            if (!requestMessage.Headers.Date.HasValue)
            {
                return null;
            }

            DateTime date = requestMessage.Headers.Date.Value.UtcDateTime;

            string md5 = requestMessage.Content == null ||
                requestMessage.Content.Headers.ContentMD5 == null ? string.Empty
                : Convert.ToBase64String(requestMessage.Content.Headers.ContentMD5);

            string httpMethod = requestMessage.Method.Method;

            // string contentType = requestMessage.Content.Headers.ContentType.MediaType;
            if (!requestMessage.Headers.Contains(Configuration.UsernameHeader))
            {
                return null;
            }

            string encryptusername = requestMessage.Headers
                .GetValues(Configuration.UsernameHeader).First();
            string decryptusername = MD5Helper.Decrypt(encryptusername);
            string username = decryptusername.Substring(0, decryptusername.IndexOf("###"));
            string uri = requestMessage.RequestUri.AbsolutePath.ToLower();

            // you may need to add more headers if thats required for security reasons
            string representation = string.Join(string.Empty, httpMethod, md5, username, uri);

            // string representation = String.Join("", httpMethod,
            //    md5,  date.ToString("dd/MM/yyyy HH:mm:ss"),
            //    username, uri);
            return representation;
        }

        /// <summary>
        /// Determines whether [is request valid] [the specified request message].
        /// </summary>
        /// <param name="requestMessage">The request message.</param>
        /// <returns><c>true</c> if [is request valid] [the specified request message]; otherwise, <c>false</c>.</returns>
        private bool IsRequestValid(HttpRequestMessage requestMessage)
        {
            // for simplicity I am omitting headers check (all required headers should be present)
            return true;
        }
    }
}
