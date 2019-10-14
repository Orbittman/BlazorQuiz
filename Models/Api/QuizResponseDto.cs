using System.Collections.Generic;

namespace Models.Api
{
    public class QuizResponseDto
    {
        public QuizResponseDto(QuizDto quizDto)
        {
            Quiz = quizDto ?? new QuizDto();
            foreach(var question in Quiz.Questions)
            {
                Answers.Add(new AnswerDto { Question = question });
            }
        }

        public QuizDto Quiz { get; set; }

        public string Name { get; set; }

        // public string IpAddress { get; set; }

        public string Token { get; set; }

        public IList<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    }
}
