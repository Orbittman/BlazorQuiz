namespace MWQuizTests
{
    using AutoData;
    using Extensions;
    using Quiz.Data.Models;
    using Models.Api;
    using Xunit;

    public class ControllerIntegrationTests
    {

        [Theory, AutoIntegrationData]
        public async void QuizControllerPutMapsTheModelsCorrectly(
            TestServerFactory serverFactory,
            QuizDto quiz,
            IQuizContext context)
        {
            using (context)
            {
                using (var server = serverFactory
                    .With(context)
                    .Create())
                {
                    var client = server.CreateClient();
                    var response = await client.PutJsonAsync("api/quiz", quiz);
                }
            }
        }
    }
}