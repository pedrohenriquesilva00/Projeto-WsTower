using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinWsTower.Helpers
{
        public static class HttpClientExtensions
        {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent iContent)
            {
                var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = iContent,
                Version = HttpVersion.Version11
                };

                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    response = await client.SendAsync(request);
                }
                catch (TaskCanceledException e)
                {
                    Debug.WriteLine("ERROR: " + e.ToString());
                }

                return response;
            }
    }
}
