using System.Threading.Tasks;

namespace QuizClient
{
    public interface IClient
    {
         Task<TResponse> GetAsync<TResponse>(string path);
    }
}