using Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace FluentValidation.Blazor
{
    public class FluentValidationValidator : ComponentBase
    {
        [Inject]
        private IValidationFactory ValidationFactory { get; set; }

        [CascadingParameter] EditContext CurrentEditContext { get; set; }

        protected override void OnInitialized()
        {
            if (ValidationFactory == null)
            {
                throw new InvalidOperationException($"{nameof(FluentValidationValidator)} requires a validation factory");
            }

            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException($"{nameof(FluentValidationValidator)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. For example, you can use {nameof(FluentValidationValidator)} " +
                    $"inside an {nameof(EditForm)}.");
            }

            CurrentEditContext.AddFluentValidation(ValidationFactory);
        }
    }
}