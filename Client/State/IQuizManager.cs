using Models.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.State
{
    public interface IQuizManager
    {
        event Action OnChange;

        IList<QuizDto> Quizes { get; }

        Task InitialiseQuizes();

        Task<QuizDto> GetQuiz(int Id);
    }
}