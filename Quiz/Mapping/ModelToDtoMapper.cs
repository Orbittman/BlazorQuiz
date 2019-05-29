namespace Quiz.Mapping
{
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Models.Api;

    public class ModelToDtoMapper : ITypeConverter<QuizDto, Quiz>
    {
        public Quiz Convert(QuizDto source, Quiz destination, ResolutionContext context)
        {
            return new Quiz
            {
                Id = source.Id,
                Date = source.Date,
                EndTime = source.EndTime,
                Name = source.Name,
                Questions = source.Questions.Select(q => new Question
                {
                    Id = q.Id,
                    QuizId = source.Id,
                    Options = q.Options.Select(o => new Option
                    {
                        Id = o.Id,
                        Text = o.Text,
                        QuestionId = q.Id
                    }).ToArray()
                }).ToArray()
            };
        }
    }
}
