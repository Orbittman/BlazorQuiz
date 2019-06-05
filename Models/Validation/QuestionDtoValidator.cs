using FluentValidation;
using Models.Api;

namespace Models.Validation
{
    public class QuestionDtoValidator : AbstractValidator<QuestionDto>
    {
        public QuestionDtoValidator()
        {
            RuleFor(x => x.Text).Must(x => !string.IsNullOrEmpty(x)).WithMessage("The question text mustn't be empty");
            RuleFor(x => x.Options).NotEmpty().WithMessage("The question must have some options");
        }
    }
}
