using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OohInterview.Api.Common.Controllers;
using OohInterview.Queries.Campaigns.List;

namespace OohInterview.Api.Campaigns.List
{
    public class ListCampaignsController: BaseController
    {
        private readonly IListCampaigns _listCampaignsQuery;

        public ListCampaignsController(IListCampaigns listCampaignsQuery)
        {
            _listCampaignsQuery = listCampaignsQuery;
        }

        [HttpGet]
        [Route("campaigns")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ListCampaignsResponse> ListCampaigns(CancellationToken cancellationToken)
        {
            var campaigns = _listCampaignsQuery.List(cancellationToken);

            var response = ListCampaignsResponse.FromQuery(campaigns);
            return Ok(response);
        }
    }
}