using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OohInterview.Api.Common.Controllers;

namespace OohInterview.Api.Avails.Search
{
    public class SearchAvailabilitiesController: BaseController
    {
        [HttpPost]
        [Route("avails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<SearchAvailsResponse> ListFaces([FromBody]SearchAvailsQueryParameters queryParameters)
        {
            throw new NotImplementedException();
        }
    }
}