using FluentValidation;
using Models.Api;
using System.Linq;

namespace Models.Validation
{
    public class QuizResponseDtoValidator : AbstractValidator<QuizResponseDto>
    {
        public QuizResponseDtoValidator()
        {
            RuleFor(x => x).Must(q => q.Answers.All(a => a.Option != null)).WithMessage("All answers must have a choice made");
        }
    }
}
