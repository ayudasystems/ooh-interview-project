using System;
using System.Linq;
using OohInterview.DAL.Repositories;
using OohInterview.Queries.Bookings.GetByCampaign;

namespace OohInterview.Queries.Implementation.Bookings.GetByCampaign
{
    public class GetBookingsByCampaign : IGetBookingsByCampaign
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingsByCampaign(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public GetBookingsByCampaignResult Get(Guid campaignId)
        {
            var bookingPocos = _bookingRepository
                .GetBookings()
                .Where(b => b.CampaignId == campaignId);
            var bookings = bookingPocos
                .Select(
                    b =>
                        new GetBookingsByCampaignResult.Booking(b.FaceId));
            return new GetBookingsByCampaignResult(bookings);
        }
    }
}