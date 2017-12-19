using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Class HMACAuthenticationHandler.
    /// </summary>
    public class HmacAuthenticationHandler : DelegatingHandler
    {
        /// <summary>
        /// The unauthorized message
        /// </summary>
        private const string UnauthorizedMessage = "Unauthorized request";

        /// <summary>
        /// The _secret repository
        /// </summary>
        private readonly ISecretRepository secretRepository;

        /// <summary>
        /// The _representation builder
        /// </summary>
        private readonly IBuildMessageRepresentation representationBuilder;

        /// <summary>
        /// The _signature calculator
        /// </summary>
        private readonly ICalculteSignature signatureCalculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="HmacAuthenticationHandler"/> class.
        /// </summary>
        /// <param name="secretRepository">The secret repository.</param>
        /// <param name="representationBuilder">The representation builder.</param>
        /// <param name="signatureCalculator">The signature calculator.</param>
        public HmacAuthenticationHandler(ISecretRepository secretRepository, IBuildMessageRepresentation representationBuilder, ICalculteSignature signatureCalculator)
        {
            this.secretRepository = secretRepository;
            this.representationBuilder = representationBuilder;
            this.signatureCalculator = signatureCalculator;
        }

        /// <summary>
        /// send as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.</returns>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var isAuthenticated = await this.IsAuthenticated(request);

            if (!isAuthenticated)
            {
                var response = request
                    .CreateErrorResponse(HttpStatusCode.Unauthorized, UnauthorizedMessage);
                response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(
                    Configuration.AuthenticationScheme));
                return response;
            }

            return await base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// Determines whether the specified request message is authenticated.
        /// </summary>
        /// <param name="requestMessage">The request message.</param>
        /// <returns>return BOOL task</returns>
        protected async Task<bool> IsAuthenticated(HttpRequestMessage requestMessage)
        {
            if (requestMessage.RequestUri.OriginalString.Contains("GetTitleMetadataFieldsForService"))
            {
                return true;
            }

            if (!requestMessage.Headers.Contains(Configuration.UsernameHeader))
            {
                return false;
            }

            var isDateValid = this.IsDateValid(requestMessage);
            if (!isDateValid)
            {
                return false;
            }

            if (requestMessage.Headers.Authorization == null
                || requestMessage.Headers.Authorization.Scheme != Configuration.AuthenticationScheme)
            {
                return false;
            }

            string encryptusername = requestMessage.Headers.GetValues(Configuration.UsernameHeader).First();
            string username = MD5Helper.Decrypt(encryptusername);
            var secret = this.secretRepository.GetSecretForUser(username.Substring(0, username.IndexOf("###")));

            // var secret = _secretRepository.GetSecretForUser(username);
            if (secret == null)
            {
                return false;
            }

            var representation = this.representationBuilder.BuildRequestRepresentation(requestMessage);
            if (representation == null)
            {
                return false;
            }

            if (requestMessage.Content.Headers.ContentMD5 != null
                && !await this.IsMd5Valid(requestMessage))
            {
                return false;
            }

            var signature = this.signatureCalculator.Signature(secret, representation);

            //// if (MemoryCache.Default.Contains(signature))
            //// {
            ////    return false;
            //// }

            var result = requestMessage.Headers.Authorization.Parameter == signature;
            if (result == true)
            {
                MemoryCache.Default.Add(signature, username, DateTimeOffset.UtcNow.AddMinutes(Configuration.ValidityPeriodInMinutes));
            }

            return result;
        }

        /// <summary>
        /// Determines whether [is MD5 valid] [the specified request message].
        /// </summary>
        /// <param name="requestMessage">The request message.</param>
        /// <returns>return BOOL task</returns>
        private async Task<bool> IsMd5Valid(HttpRequestMessage requestMessage)
        {
            var hashHeader = requestMessage.Content.Headers.ContentMD5;
            if (requestMessage.Content == null)
            {
                return hashHeader == null || hashHeader.Length == 0;
            }

            var hash = await MD5Helper.ComputeHash(requestMessage.Content);
            return hash.SequenceEqual(hashHeader);
        }

        /// <summary>
        /// Determines whether [is date valid] [the specified request message].
        /// </summary>
        /// <param name="requestMessage">The request message.</param>
        /// <returns><c>true</c> if [is date valid] [the specified request message]; otherwise, <c>false</c>.</returns>
        private bool IsDateValid(HttpRequestMessage requestMessage)
        {
            if (requestMessage.Headers.Contains(Configuration.DateValueHeader))
            {
                if (!string.IsNullOrEmpty(requestMessage.Headers.GetValues(Configuration.DateValueHeader).First()))
                {
                    requestMessage.Headers.Add("Date", requestMessage.Headers.GetValues(Configuration.DateValueHeader).First());
                }
            }

            if (!requestMessage.Headers.Date.HasValue)
            {
                return false;
            }

            var utcNow = DateTime.UtcNow;
            var date = requestMessage.Headers.Date.Value.UtcDateTime;
            if (date >= utcNow.AddMinutes(Configuration.ValidityPeriodInMinutes)
                || date <= utcNow.AddMinutes(-Configuration.ValidityPeriodInMinutes))
            {
                return false;
            }

            return true;
        }
    }
}
