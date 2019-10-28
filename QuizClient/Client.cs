using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuizClient
{
    public class Client : IClient
    {
        private HttpClient _httpClient;

        public Client()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Methods", "*");
            _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "*");
            _httpClient.DefaultRequestHeaders.Add("Access-Control-Max-Age", "86400");
        
        }

        public async Task<TResponse> GetAsync<TResponse>(string path)
        {
            TResponse response = default;
            var result = await _httpClient.GetAsync(path);
            if (!result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<TResponse>(content);
            }

            return response;
        }
    }
}
