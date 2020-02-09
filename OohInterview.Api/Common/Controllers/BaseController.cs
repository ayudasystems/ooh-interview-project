using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OohInterview.Api.Common.Controllers
{
    [ApiController]
    [Route("/api/v1/")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class BaseController : ControllerBase
    {
        public BadRequestObjectResult BadRequestWithProblem(string title, string? detail = null)
        {
            var problemDetails = new ProblemDetails
            {
                Detail = detail,
                Title = title
            };
            return BadRequest(problemDetails);
        }
    }
}