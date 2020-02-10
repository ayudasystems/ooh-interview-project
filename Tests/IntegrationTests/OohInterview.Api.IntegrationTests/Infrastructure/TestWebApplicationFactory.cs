using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OohInterview.Api.IntegrationTests.Infrastructure
{
    public class TestWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup: class
    {
        public ServiceProvider? ServiceProvider { get; private set; }
        
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureAppConfiguration(
                    configurationBuilder =>
                    {
                        configurationBuilder.AddConfiguration(CreateConfiguration());
                    })
                .ConfigureServices(services => {})
                .ConfigureTestServices(services =>
                {
                    //todo: the db needs to be cleared for each test, might not be right now
                    ServiceProvider = services.BuildServiceProvider();
                });
        }

        private static IConfiguration CreateConfiguration()
        {
            var configValues = new[]
            {
                new KeyValuePair<string, string>("UI:ContentDirectory", "null"),
            };
            
            return new ConfigurationBuilder()
                .AddInMemoryCollection(configValues)
                .Build();
        }
    }
}