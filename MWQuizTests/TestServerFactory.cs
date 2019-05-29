namespace MWQuizTests
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Quiz;
    using NSubstitute;

    public class TestServerFactory
    {
        private readonly IDictionary<string, string> settings = new Dictionary<string, string>();

        private readonly List<ServiceDescriptor> registrations = new List<ServiceDescriptor>();

        public TestServerFactory WithMock<T>(T instance)
            where T : class
        {
            With(Substitute.For<T>());
            return this;
        }

        public TestServerFactory WithSetting(string key, string value)
        {
            settings.Add(key, value);
            return this;
        }

        public TestServerFactory With<T>(T instance)
        {
            registrations.Add(new ServiceDescriptor(typeof(T), instance));
            return this;
        }

        public TestServer Create()
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration(
                    (ctx, cfg) =>
                    {
                        cfg.AddJsonFile("appsettings.json", true, true)
                            .AddEnvironmentVariables()
                            .AddInMemoryCollection(settings);
                    })
                .ConfigureServices(
                    s =>
                    {
                        foreach (var registration in registrations)
                        {
                            s.Add(registration);
                        }
                    });

            return new TestServer(webHostBuilder);
        }
    }
}