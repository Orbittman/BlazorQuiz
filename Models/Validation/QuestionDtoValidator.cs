using FluentValidation;
using Models.Api;
using System.Linq;

namespace Models.Validation
{
    public class QuestionDtoValidator : AbstractValidator<QuestionDto>
    {
        public QuestionDtoValidator()
        {
            RuleFor(x => x.Text).NotEmpty().WithMessage("The question text mustn't be empty");
            RuleForEach(x => x.Options).SetValidator(new OptionDtoValidator());
            RuleFor(x => x.Options).Must(o => o.Any(a => a.Answer)).WithMessage("At least one option must be marked as the answer"); 
            RuleFor(x => x.Options).NotEmpty().WithMessage("All questions must have at least one option");
        }
    }
}
