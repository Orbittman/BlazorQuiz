using Models.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client
{
    public interface IApiClient
    {
        Task<TResponse> GetAsync<TResponse>(string path);

        Task<bool> PutAsync<TRequest>(string path, TRequest model);

        Task<bool> PostAsync<TRequest>(string path, TRequest model);

        Task<IEnumerable<QuizDto>> GetQuizes();

        Task<QuizResponseDto> GetResponse(int quizId);
    }
}