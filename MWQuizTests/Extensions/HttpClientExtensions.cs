namespace MWQuizTests.Extensions
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PutJsonAsync<TData>(
            this HttpClient client,
            string requestUri,
            TData data)
        {
            var content = data == null ? null : ToJsonStringContent(data);
            return client.PutAsync(requestUri, content);
        }

        private static HttpContent ToJsonStringContent<TData>(TData data)
        {
            var settings =
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), };

            var json = JsonConvert.SerializeObject(data, settings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
