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
    /// Class ResponseContentMD5Handler.
    /// </summary>
    public class ResponseContentMd5Handler : DelegatingHandler
    {
        /// <summary>
        /// send as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.</returns>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                byte[] content = await response.Content.ReadAsByteArrayAsync();
                MD5 md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(content);
                response.Content.Headers.ContentMD5 = hash;
            }

            return response;
        }
    }
}
