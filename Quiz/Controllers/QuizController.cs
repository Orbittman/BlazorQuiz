namespace Quiz.Controllers
{
    using System.Linq;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models.Api;
    using AutoMapper;
    using System;
    using Quiz.Extensions;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : Controller
    {
        private readonly IQuizContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor accessor;

        public QuizController(IQuizContext context, IMapper mapper, IHttpContextAccessor accessor)
        {
            this.context = context;
            this.mapper = mapper;
            this.accessor = accessor;
        }

        [HttpGet]
        public ActionResult<QuizDto[]> GetQuizes()
        {
            var quizes = context.Quizes.Include(q => q.Questions).ThenInclude(q => q.Options).ToArray();
            return mapper.Map<QuizDto[]>(quizes);
        }

        [HttpGet("responses/{id:int}")]
        public async Task<ActionResult<QuizResponseDto>> GetQuiz(int id)
        {
            var ipAddress = accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            var token = Request.Cookies["token"] ?? Guid.NewGuid().ToString("N");
            var quizTask = context.Quizes.Include(q => q.Questions).ThenInclude(q => q.Options).SingleOrDefaultAsync(q => q.Id == id);
            var response = context.Responses.Include(r => r.Answers).Include(r => r.Quiz).Where(r => r.Token == token).SingleOrDefaultAsync(r => r.Quiz.Id == id);

            await Task.WhenAll(response, quizTask);

            var quiz = quizTask.Result;
            if (response.Result == null) {
                var quizDto = mapper.Map<QuizDto>(quiz);
                return new QuizResponseDto(quizDto)
                {
                    IpAddress = ipAddress,
                    Token = token
                };
            }

            var quizExists = context.Quizes.Any(q => q.Id == id);
            if (!quizExists)
            {
                return NotFound(id);
            }

            var responseDto = mapper.Map<QuizResponseDto>(response.Result);
            return responseDto;
        }

        [HttpPut]
        public ActionResult<QuizDto> Put(QuizDto quizDto)
        {
            var quiz = mapper.Map<Quiz>(quizDto);
            context.Quizes.Add(quiz);
            context.SaveChanges();

            return quizDto;
        }

        [HttpPost]
        public ActionResult<QuizDto> Post(QuizDto quizDto)
        {
            var quiz = context.Quizes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
                .SingleOrDefault(q => q.Id == quizDto.Id);

            mapper.Map(quizDto, quiz);
            context.Quizes.Update(quiz);
            context.SaveChanges();

            return quizDto;
        }

        [HttpDelete("{id:int}")]
        public ActionResult<int> Delete(int id)
        {
            var quiz = context.Quizes.Remove(new Quiz {Id = id});
            context.SaveChanges();

            return quiz.Entity.Id;
        }
    }
}