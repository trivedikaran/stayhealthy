using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Class HMACSigningHandler.
    /// </summary>
    public class HmacSigningHandler : HttpClientHandler
    {
        /// <summary>
        /// The secret repository
        /// </summary>
        private readonly ISecretRepository secretRepository;

        /// <summary>
        /// The representation builder
        /// </summary>
        private readonly IBuildMessageRepresentation representationBuilder;

        /// <summary>
        /// The signature calculator
        /// </summary>
        private readonly ICalculteSignature signatureCalculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="HmacSigningHandler"/> class.
        /// </summary>
        /// <param name="secretRepository">The secret repository.</param>
        /// <param name="representationBuilder">The representation builder.</param>
        /// <param name="signatureCalculator">The signature calculator.</param>
        public HmacSigningHandler(ISecretRepository secretRepository, IBuildMessageRepresentation representationBuilder, ICalculteSignature signatureCalculator)
        {
            this.secretRepository = secretRepository;
            this.representationBuilder = representationBuilder;
            this.signatureCalculator = signatureCalculator;
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Creates an instance of  <see cref="T:System.Net.Http.HttpResponseMessage" /> based on the information provided in the <see cref="T:System.Net.Http.HttpRequestMessage" /> as an operation that will not block.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains(Configuration.UsernameHeader))
            {
                request.Headers.Add(Configuration.UsernameHeader, this.Username);
            }

            request.Headers.Date = new DateTimeOffset(DateTime.Now, DateTime.Now - DateTime.UtcNow);
            var representation = this.representationBuilder.BuildRequestRepresentation(request);
            var decryptUser = MD5Helper.Decrypt(this.Username); // Username;
            var secret = this.secretRepository.GetSecretForUser(decryptUser.Substring(0, decryptUser.IndexOf("###")));

            // var secret = _secretRepository.GetSecretForUser(Username);
            string signature = this.signatureCalculator.Signature(secret, representation);

            var header = new AuthenticationHeaderValue(Configuration.AuthenticationScheme, signature);

            request.Headers.Authorization = header;
            return base.SendAsync(request, cancellationToken);
        }
    }
}
