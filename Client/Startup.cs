using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Models.Validation;

namespace Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IApiClient, ApiClient>();
            services.AddSingleton<IValidationFactory, ValidationFactory>();
            services.AddTransient<IValidator, QuizDtoValidator>();
            services.AddTransient<IValidator, QuestionDtoValidator>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
