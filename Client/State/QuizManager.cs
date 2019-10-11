using Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.State
{
    public class QuizManager : IQuizManager
    {
        private readonly IApiClient _apiClient;
        public event Action OnChange;

        public QuizManager(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IList<QuizDto> Quizes { get; private set; }

        public async Task InitialiseQuizes()
        {
            var quizesResponse = await _apiClient.GetQuizes();
            Quizes = quizesResponse.ToList();
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
