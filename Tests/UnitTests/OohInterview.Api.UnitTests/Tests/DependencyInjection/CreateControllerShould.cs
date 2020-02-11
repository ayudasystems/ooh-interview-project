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

        /// <summary>
        /// This test attempts to instantiate every controller.
        /// To do this, it uses the Dependency Injection Container to find the required dependencies.
        /// Any dependencies that have not been register for Dependency Injection will cause test failures.
        /// If a test fails, check which new classes / interfaces have been added to constructors and
        /// make sure that they are registered in one of the classes in OohInterview.DependencyInjection.
        /// If they are registered correctly, then there may be an exception thrown in a constructor of
        /// a dependency.
        /// </summary>
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