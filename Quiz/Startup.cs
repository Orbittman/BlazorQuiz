using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;

using Quiz.Data.Models;
using Microsoft.AspNetCore.Http;
using FluentValidation.AspNetCore;
using Models.Validation;

namespace Quiz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string corsOrigins = "corsOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddFluentValidation(options =>
                { 
                    options.ImplicitlyValidateChildProperties = true;
                    options.RegisterValidatorsFromAssemblyContaining<QuizDtoValidator>();
                });

            services.AddCors(options =>
            {
                options.AddPolicy(corsOrigins,
                    builder =>
                    {
                        builder
                            .WithOrigins("https://localhost:5001", "http://localhost:5000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(ex => ex.AddProfile<Mapping.MapperProfile>(), new System.Reflection.Assembly[0]);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<IQuizContext, QuizContext>(ServiceLifetime.Transient);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(corsOrigins);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
