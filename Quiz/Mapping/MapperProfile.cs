namespace Quiz.Mapping
{
    using AutoMapper;
    using Data.Models;
    using Models.Api;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<Quiz, QuizDto>();
            CreateMap<Option, OptionDto>();
            CreateMap<Answer, AnswerDto>();

            CreateMap<QuizDto, Quiz>();
            CreateMap<QuestionDto, Question>();
            CreateMap<OptionDto, Option>();
            CreateMap<AnswerDto, Answer>();
        }
    }
}
