using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OohInterview.Api.Common.Controllers;
using OohInterview.Queries.Bookings.GetByCampaign;

namespace OohInterview.Api.Campaigns.Bookings
{
    public class ListCampaignBookingsController : BaseController
    {
        private readonly IGetBookingsByCampaign _bookingsQuery;

        public ListCampaignBookingsController(IGetBookingsByCampaign bookingsQuery)
        {
            _bookingsQuery = bookingsQuery;
        }

        [HttpGet]
        [Route("campaign/{id}/bookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ListCampaignBookingsResponse> ListCampaigns(string id)
        {
            if (!Guid.TryParse(id, out var campaignId))
                return BadRequest("The Campaign ID is not valid");

            var bookings = _bookingsQuery.Get(campaignId);

            var response = ListCampaignBookingsResponse.FromQuery(bookings);
            return Ok(response);
        }
    }
}