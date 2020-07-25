using Android.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWsTower.Models;

namespace XamarinWsTower.Helpers
{
   public static class Utils
    {
        private static HttpClient client;

        public static string token { get; set; }

        public static HttpClient getClient
        {
            get
            {
                if (client == null)
                {
                    client = new HttpClient(); 
                    client.BaseAddress = new Uri("http://192.168.0.105:5000/api/");
                }
                return client;
            }
        }

        public static ImageSource ByteToImage(byte[] imageByte)
        {
            //! Esse linha de código abaixo só funciona com o '() =>' (Func<T>'
            var returnImage = StreamImageSource.FromStream(() => new MemoryStream(imageByte));
            return returnImage;
        }

        public static Usuario TokenToUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
            int id = Convert.ToInt32(jwtToken.Claims.First(claim => claim.Type == "jti").Value);

            try
            {
                HttpClient client = Utils.getClient;
                HttpResponseMessage response = client.GetAsync("Usuarios/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Usuario>(json);
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<HttpResponseMessage> PatchAsync(HttpClient client, Uri requestUri, HttpContent iContent)
        {
            var method = new HttpMethod("PATCH");

            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = iContent
            };

            HttpResponseMessage response = new HttpResponseMessage();
            // In case you want to set a timeout
            //CancellationToken cancellationToken = new CancellationTokenSource(60).Token;

            try
            {
                response = await client.SendAsync(request);
                // If you want to use the timeout you set
                //response = await client.SendRequestAsync(request).AsTask(cancellationToken);
            }
            catch (TaskCanceledException e)
            {
                Debug.WriteLine("ERROR: " + e.ToString());
            }

            return response;
        }

        //public static byte[] AsJpeg(byte[] data)
        //{
        //    using (var inStream = new MemoryStream(data))
        //    using (var outStream = new MemoryStream())
        //    {
        //        var imageStream = Image.Stream;
        //        imageStream.Save(outStream, ImageFormatType.Jpeg);
        //        return outStream.ToArray();
        //    }
        //}


    }
}
