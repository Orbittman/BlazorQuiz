using Models.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.State
{
    public interface IQuizManager
    {
        Task InitialiseQuizes();
    }
}