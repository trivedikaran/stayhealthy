using StayHealthy.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using StayHealthy.Helpers;

namespace StayHealthy.Common.Helpers
{
    public class WebApiHelper
    {
        #region WebAPi Common Method

        /// <summary>
        /// HTTPs the client request response.
        /// </summary>
        /// <typeparam name="T">T object</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="uri">The URI.</param>
        /// <returns>Return T object</returns>
        public static async Task<T> HttpClientRequestReponce<T>(T value, string uri)
        {
            var signingHandler = new HmacSigningHandler(new DummySecretRepository(), new CanonicalRepresentationBuilder(), new HmacSignatureCalculator());

            signingHandler.Username = Security.Encrypt("username" + "###" + DateTime.UtcNow);
            var client = new HttpClient(new RequestContentMd5Handler()
            {
                InnerHandler = signingHandler
            });

            client.BaseAddress = new Uri(ProjectConfiguration.WebApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<T>();
                return (T)Convert.ChangeType(result, typeof(T));
            }

            return default(T);
        }

        /// <summary>
        /// HTTPs the client request response synchronize.
        /// </summary>
        /// <typeparam name="T">T object</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="uri">The URI.</param>
        /// <returns>return T object</returns>
        public static T HttpClientRequestReponceSync<T>(T value, string uri)
        {
            var signingHandler = new HmacSigningHandler(new DummySecretRepository(), new CanonicalRepresentationBuilder(), new HmacSignatureCalculator());

            signingHandler.Username = Security.Encrypt("username" + "###" + DateTime.UtcNow);

            var client = new HttpClient(new RequestContentMd5SyncHandler()
            {
                InnerHandler = signingHandler
            });

            client.BaseAddress = new Uri(ProjectConfiguration.WebApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpresult = client.GetAsync(uri).Result;

            if (httpresult.IsSuccessStatusCode)
            {
                var result = httpresult.Content.ReadAsAsync<T>();
                return (T)Convert.ChangeType(result.Result, typeof(T));
            }

            return default(T);
        }

        /// <summary>
        /// HTTPs the client post.
        /// </summary>
        /// <typeparam name="T">T object</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="uri">The URI.</param>
        /// <returns>Return T object</returns>
        public static async Task<string> HttpClientPost<T>(T value, string uri)
        {
            var signingHandler = new HmacSigningHandler(new DummySecretRepository(), new CanonicalRepresentationBuilder(), new HmacSignatureCalculator());
            signingHandler.Username = Security.Encrypt("username" + "###" + DateTime.UtcNow);
            var client = new HttpClient(new RequestContentMd5Handler()
            {
                InnerHandler = signingHandler
            });

            client.BaseAddress = new Uri(ProjectConfiguration.WebApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync(uri, value);
            if (response.IsSuccessStatusCode)
            {
                return string.Empty;
            }

            return response.StatusCode.ToString();
        }

        /// <summary>
        /// HTTPs the client post pass entity return entity.
        /// </summary>
        /// <typeparam name="O">O object</typeparam>
        /// <typeparam name="I">I object</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="uri">The URI.</param>
        /// <returns>Return T Object</returns>
        public static async Task<O> HttpClientPostPassEntityReturnEntity<O, I>(I value, string uri)
        {
            var signingHandler = new HmacSigningHandler(new DummySecretRepository(), new CanonicalRepresentationBuilder(), new HmacSignatureCalculator());
            signingHandler.Username = Security.Encrypt("username" + "###" + DateTime.UtcNow);

            var client = new HttpClient(new RequestContentMd5Handler()
            {
                InnerHandler = signingHandler
            });

            client.BaseAddress = new Uri(ProjectConfiguration.WebApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync(uri, value);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<O>();
                return (O)Convert.ChangeType(result, typeof(O));
            }

            return default(O);
        }

        /// <summary>
        /// HTTPs the client post pass model return base API.
        /// </summary>
        /// <typeparam name="T">T object</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="uri">The URI.</param>
        /// <returns>Return T Object</returns>
        public static async Task<T> HttpClientPostPassModelReturnBaseApi<T>(T value, string uri)
        {
            var signingHandler = new HmacSigningHandler(new DummySecretRepository(), new CanonicalRepresentationBuilder(), new HmacSignatureCalculator());

            signingHandler.Username = Security.Encrypt("username" + "###" + DateTime.UtcNow);

            var client = new HttpClient(new RequestContentMd5Handler()
            {
                InnerHandler = signingHandler
            });

            client.BaseAddress = new Uri(ProjectConfiguration.WebApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync(uri, value);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<T>();
                return (T)Convert.ChangeType(result, typeof(T));
            }

            return default(T);
        }

        /// <summary>
        /// Clients the delete request.
        /// </summary>
        /// <typeparam name="T">T object</typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns>Return T object</returns>
        public static async Task<T> ClientDeleteRequest<T>(string uri)
        {
            var signingHandler = new HmacSigningHandler(new DummySecretRepository(), new CanonicalRepresentationBuilder(), new HmacSignatureCalculator());
            signingHandler.Username = Security.Encrypt("username" + "###" + DateTime.UtcNow);

            var client = new HttpClient(new RequestContentMd5Handler()
            {
                InnerHandler = signingHandler
            });

            client.BaseAddress = new Uri(ProjectConfiguration.WebApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<T>();
                return (T)Convert.ChangeType(result, typeof(T));
            }

            return default(T);
        }
        #endregion
    }
}
