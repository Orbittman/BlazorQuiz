namespace Quiz.Controllers
{
    using System.Linq;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models.Api;
    using AutoMapper;

    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : Controller
    {
        private readonly IQuizContext context;
        private readonly IMapper mapper;

        public QuizController(IQuizContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<QuizDto[]> Quizes()
        {
            var quizes = context.Quizes.Include(q => q.Questions).ThenInclude(q => q.Options).ToArray();
            return mapper.Map<QuizDto[]>(quizes);
        }

        [HttpGet("{id:int}")]
        public ActionResult<QuizDto> Get(int id)
        {
            var quiz = context.Quizes.SingleOrDefault(q => q.Id == id);
            if (quiz != null)
            {
                return mapper.Map<QuizDto>(quiz);
            }

            return NotFound(id);
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
            var quiz = mapper.Map<Quiz>(quizDto);
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
