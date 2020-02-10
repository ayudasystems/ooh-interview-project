using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using OohInterview.Api.IntegrationTests.Infrastructure;
using OohInterview.DAL;
using Xunit;

namespace OohInterview.Api.IntegrationTests.Tests
{
    public abstract class BaseIntegrationTest : 
        IClassFixture<TestWebApplicationFactory<Startup>>
    {
        private const string BaseUrl = "/api/v1/";
    
        protected readonly HttpClient Client;
        protected readonly DataContext Database;
        
        private readonly TestWebApplicationFactory<Startup> _factory;

        public BaseIntegrationTest(TestWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            Client = _factory.CreateClient();
            Database = GetInjectedService<DataContext>();
        }

        protected string CreateUrl(string endpoint)
        {
            return $"{BaseUrl}{endpoint}";
        }

        protected T GetInjectedService<T>()
        {
            return _factory.ServiceProvider.GetService<T>();
        }
    }
}