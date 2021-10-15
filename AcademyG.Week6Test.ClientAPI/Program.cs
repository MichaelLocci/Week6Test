using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AcademyG.Week6Test.ClientAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            #region Get Order

            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44319/api/orders")
            };

            HttpResponseMessage httpResponse = await client.SendAsync(httpRequest);

            if (httpResponse.IsSuccessStatusCode)
            {
                string jsonData = await httpResponse.Content.ReadAsStringAsync();
                //var results = JsonConvert.DeserializeObject<List<OrderContract>>(jsonData);

                
            }

            #endregion
        }
    }
}
