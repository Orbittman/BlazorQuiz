using Client.Extensions;
using FluentValidation;
using Infrastructure;

using Blazorise;
using Blazorise.Material;
using Blazorise.Icons.Material;

using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Models.Validation;
using System.Threading.Tasks;
using Client.State;

namespace Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IApiClient, ApiClient>();
            services.AddSingleton<IValidationFactory, ValidationFactory>();
            services.AddSingleton<IQuizManager, QuizManager>();

            services.AddTransient<IValidator, QuizDtoValidator>();
            services.AddTransient<IValidator, QuestionDtoValidator>();
            services.AddTransient<IValidator, OptionDtoValidator>();
            services.AddTransient<IValidator, QuizResponseDtoValidator>();

            services
                .AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = false;
                }) // from v0.6.0-preview4
                .AddMaterialProviders()
                .AddMaterialIcons();
        }

        public Task Configure(IComponentsApplicationBuilder app)
        {
            app.Services
                .UseMaterialProviders()
                .UseMaterialIcons();
            app.AddComponent<App>("app");

            return app.Initialise();
        }
    }
}
