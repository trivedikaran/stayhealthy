using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Authentication
{
    /// <summary>
    /// Class RequestContentMD5SyncHandler.
    /// </summary>
    public class RequestContentMd5SyncHandler : DelegatingHandler
    {
        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (request.Content == null)
            {
                return base.SendAsync(request, cancellationToken);
            }

            byte[] content = request.Content.ReadAsByteArrayAsync().Result;
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(content);
            request.Content.Headers.ContentMD5 = hash;
            var response = base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}
