using Quiz.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Extensions
{
    public static class ModelExtensions
    {
        public static IEnumerable<Answer> ToAnswers(this Data.Models.Quiz quiz)
        {
            return quiz.Questions.Select(q => new Answer
            {
                Question = q
            });
        }
    }
}
