using FluentValidation;
using Models.Api;

namespace Models.Validation
{
    public class QuizDtoValidator : AbstractValidator<QuizDto>
    {
        public QuizDtoValidator()
        {
            RuleFor(x => x.Name).Must(x => !string.IsNullOrEmpty(x)).WithMessage("The quiz name mustn't be empty");
            RuleFor(x => x.Questions).NotEmpty().WithMessage("The quiz must have some questions");
        }
    }
}
