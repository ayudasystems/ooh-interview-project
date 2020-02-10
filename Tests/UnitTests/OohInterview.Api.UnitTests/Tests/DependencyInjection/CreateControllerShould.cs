using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OohInterview.Api.Common.Controllers;
using Xunit;

namespace OohInterview.Api.UnitTests.Tests.DependencyInjection
{
    public class CreateControllerShould
    {
        private readonly IServiceCollection _services;

        public CreateControllerShould()
        {
            _services = RegisterServices();
        }

        [Theory]
        [MemberData(nameof(Controllers))]
        public void SuccessfullyLoadDependencies(Type controllerType)
        {
            _services.AddTransient(controllerType);
            var provider = _services.BuildServiceProvider();

            var controller = provider.GetRequiredService(controllerType);

            Assert.NotNull(controller);
        }

        public static IEnumerable<object[]> Controllers()
        {
            return ControllerFinder
                .FindControllers(typeof(BaseController))
                .Select(x => new[] { x });
        }

        private static IServiceCollection RegisterServices()
        {
            var config = CreateConfiguration();
            var startup = new Startup(config);

            var services = new ServiceCollection();
            startup.ConfigureServices(services);

            return services;
        }

        private static IConfigurationRoot CreateConfiguration()
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