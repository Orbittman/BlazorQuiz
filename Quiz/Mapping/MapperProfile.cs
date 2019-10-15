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
            CreateMap<QuizDto, Quiz>();
            CreateMap<Option, OptionDto>();
            CreateMap<Answer, AnswerDto>();
            CreateMap<QuizResponse, QuizResponseDto>();

            CreateMap<QuestionDto, Question>();
            CreateMap<OptionDto, Option>();
            CreateMap<AnswerDto, Answer>();
            CreateMap<QuizResponseDto, QuizResponse>();
        }
    }
}
