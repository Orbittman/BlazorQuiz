using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ApiClient : IApiClient
    {
        private Uri baseAddress = new Uri("http://localhost:5000/");

        public ApiClient()
        {
        
        }

        public async Task<TResponse> GetAsync<TResponse>(string path)
        {
            TResponse response = default;
            using (var client = GetClient())
            {

            var result = await client.GetAsync(path);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<TResponse>(content);
            }
            }

            return response;
        }

        public async Task<bool> PutAsync<TRequest>(string path, TRequest model)
        {
            using (var client = GetClient())
            {
                using (var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"))
                {
                    var result = await client.PutAsync(path, content);
                }
            }

            return true;
        }

        public async Task<bool> PostAsync<TRequest>(string path, TRequest model)
        {
            using (var client = GetClient())
            {
                using (var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"))
                {
                    var result = await client.PostAsync(path, content);
                }
            }

            return true;
        }


        private HttpClient GetClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/")
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            client.DefaultRequestHeaders.Add("Access-Control-Allow-Methods", "*");
            client.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "*");
            client.DefaultRequestHeaders.Add("Access-Control-Max-Age", "86400");

            return client;

        }
    }
}
