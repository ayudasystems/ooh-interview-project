using System.Net;
using System.Net.Http;
using Xunit;

namespace OohInterview.Api.IntegrationTests.Assertions
{
    internal static class HttpAssertions
    {
        public static void AssertSuccessResponse(this HttpResponseMessage response)
        {
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}