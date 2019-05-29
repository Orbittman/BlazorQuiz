using System.Threading.Tasks;

namespace Client
{
    public interface IApiClient
    {
        Task<TResponse> GetAsync<TResponse>(string path);

        Task<bool> PutAsync<TRequest>(string path, TRequest model);

        Task<bool> PostAsync<TRequest>(string path, TRequest model);
    }
}