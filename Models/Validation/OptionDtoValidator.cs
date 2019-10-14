using FluentValidation;
using Models.Api;
using System.Linq;

namespace Models.Validation
{
    public class OptionDtoValidator : AbstractValidator<OptionDto>
    {
        public OptionDtoValidator()
        {
            RuleFor(o => o.Text).NotEmpty().WithMessage("All options must have some text");
        }
    }
}
