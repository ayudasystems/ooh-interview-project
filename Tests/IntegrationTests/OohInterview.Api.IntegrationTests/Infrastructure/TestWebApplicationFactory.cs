using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OohInterview.DAL;

namespace OohInterview.Api.IntegrationTests.Infrastructure
{
    public class TestWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        public DataContext? DataContext { get; private set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureAppConfiguration(
                    configurationBuilder => { configurationBuilder.AddConfiguration(CreateConfiguration()); })
                .ConfigureServices(services => { })
                .ConfigureTestServices(
                    services =>
                    {
                        DataContext = new DataContext(false);
                        services.AddScoped<DataContext>(_ => DataContext);
                    });
        }

        private static IConfiguration CreateConfiguration()
        {
            var configValues = new[]
            {
                new KeyValuePair<string, string>("UI:ContentDirectory", "/"),
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();
        }
    }
}