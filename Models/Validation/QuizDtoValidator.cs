using FluentValidation;
using Models.Api;
using System.Linq;

namespace Models.Validation
{
    public class QuizDtoValidator : AbstractValidator<QuizDto>
    {
        public QuizDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The quiz name mustn't be empty");
            RuleFor(x => x.Questions).NotEmpty().WithMessage("The quiz must have some questions");
            RuleForEach(x => x.Questions).SetValidator(new QuestionDtoValidator());
            //RuleFor(x => x.Questions).Must(questions => questions.All(q => q.Options.All(o => !string.IsNullOrWhiteSpace(o.Text)))).WithMessage("All questions must have at least one option");
        }
    }
}
