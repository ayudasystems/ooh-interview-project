using System;

namespace OohInterview.Queries.Bookings.GetByCampaign
{
    public interface IGetBookingsByCampaign
    {
        GetBookingsByCampaignResult Get(Guid campaignId);
    }
}