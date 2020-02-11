using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Xunit;

namespace OohInterview.Api.UnitTests.Assertions
{
    public static class HttpAssertions
    {   
        public static void Assert200<TResponse>(this ActionResult<TResponse> response)
        {
            AssertStatusCode(HttpStatusCode.OK, response.Result);
        }
        
        public static TResponse AssertOkObjectResponse<TResponse>(this ActionResult<TResponse> response)
        {
            var okObjectResult = Assert.IsType<OkObjectResult>(response.Result);
            return Assert.IsType<TResponse>(okObjectResult.Value);
        }
        
        private static void AssertStatusCode(HttpStatusCode statusCode, IActionResult response)
        {
            var statusCodeResult = Assert.IsAssignableFrom<IStatusCodeActionResult>(response);
            Assert.Equal((int)statusCode, statusCodeResult.StatusCode);
        }
    }
}