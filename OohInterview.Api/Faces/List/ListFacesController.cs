using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OohInterview.Api.Common.Controllers;
using OohInterview.Queries.Faces.List;

namespace OohInterview.Api.Faces.List
{
    public class ListFacesController: BaseController
    {
        private readonly IListFaces _listFacesQuery;

        public ListFacesController(IListFaces listFacesQuery)
        {
            _listFacesQuery = listFacesQuery;
        }

        [HttpGet]
        [Route("faces")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ListFacesResponse> ListFaces()
        {
            var faces = _listFacesQuery.List();

            var response = ListFacesResponse.FromQuery(faces);
            return Ok(response);
        }
    }
}