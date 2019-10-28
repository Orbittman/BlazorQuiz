namespace Quiz.Controllers
{
    using System.Linq;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models.Api;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;
    using System;

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
            if (string.IsNullOrEmpty(accessor.HttpContext.Request.Cookies["token"]))
            {
                accessor.HttpContext.Response.Cookies.Append("token", Guid.NewGuid().ToString(), new CookieOptions { Expires=DateTime.Now.AddYears(20), HttpOnly=true, IsEssential=true, Path="/" });
            }

            return mapper.Map<QuizDto[]>(quizes);
        }

        [HttpPut("responses")]
        public async Task<ActionResult> PutResponse(QuizResponseDto quizResponse)
        {
            var existingResponse = await context.Responses.SingleOrDefaultAsync(r => r.Id == quizResponse.Quiz.Id && r.Token == GetUserToken().ToString());
            if (existingResponse != null)
            {
                return BadRequest($"This quiz has already been answered by {existingResponse.Person}");
            }

            var response = new QuizResponse
            {
                Answers = quizResponse.Answers.Select(a => new Answer { QuestionId = a.Question.Id, OptionId = a.Option.Id }).ToList(),
                Person = quizResponse.Name,
                QuizId = quizResponse.Quiz.Id,
                Token = GetUserToken().ToString()
            };

            await context.Responses.AddAsync(response);
            context.SaveChanges();

            return Ok();
        }

        [HttpGet("responses/{quizId:int}")]
        public async Task<QuizResponseDto> GetResponse(int quizId)
        {
            var quizResponse = await context
                .Responses
                .Include(r => r.Answers)
                .ThenInclude(a => a.Question)
                .ThenInclude(q => q.Options)
                .Include(r => r.Quiz)
                .SingleOrDefaultAsync(r => r.QuizId == quizId && r.Token == GetUserToken().ToString());
            if (quizResponse != null)
            {
                return new QuizResponseDto(mapper.Map<QuizDto>(quizResponse.Quiz))
                {
                    Token = quizResponse.Token,
                    Answers = quizResponse.Answers.Select(a => mapper.Map<AnswerDto>(a)).ToList(),
                    Name = quizResponse.Person,
                    Completed = true
                };
            }

            return null;
        }

        [HttpPut]
        public ActionResult<QuizDto> Put(QuizDto quizDto)
        {
            var quiz = mapper.Map<Quiz>(quizDto);
            context.Quizes.Add(quiz);
            var newId = context.SaveChanges();

            quizDto.Id = newId;

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

        private Guid GetUserToken()
        {
            if(!Guid.TryParse(accessor.HttpContext.Request.Cookies["token"], out var token))
            {
                token = Guid.NewGuid();
            }

            return token;
        }
    }
}
