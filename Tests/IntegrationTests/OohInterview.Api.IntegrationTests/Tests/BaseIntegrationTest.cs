using System;
using System.Net.Http;
using OohInterview.Api.IntegrationTests.Infrastructure;
using OohInterview.DAL;

namespace OohInterview.Api.IntegrationTests.Tests
{
    public abstract class BaseIntegrationTest
    {
        private const string BaseUrl = "/api/v1/";

        protected readonly HttpClient Client;
        protected readonly DataContext Database;

        public BaseIntegrationTest()
        {
            var factory = new TestWebApplicationFactory<Startup>();
            Client = factory.CreateClient();
            Database = factory.Database ?? throw new Exception("Failed to initialise the test database");
        }

        protected string CreateUrl(string endpoint)
        {
            return $"{BaseUrl}{endpoint}";
        }
    }
}