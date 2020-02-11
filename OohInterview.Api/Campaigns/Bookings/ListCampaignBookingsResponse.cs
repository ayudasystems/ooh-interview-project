using System.Collections.Generic;
using System.Linq;
using OohInterview.Api.Common.Responses;
using OohInterview.Queries.Bookings.GetByCampaign;

namespace OohInterview.Api.Campaigns.Bookings
{
    public class ListCampaignBookingsResponse : CollectionResponse<ListCampaignBookingsResponse.BookingResponse>
    {
        public ListCampaignBookingsResponse(List<BookingResponse> items)
            : base(items)
        {
        }

        public static ListCampaignBookingsResponse FromQuery(GetBookingsByCampaignResult result)
        {
            var response =
                result.Bookings
                    .Select(BookingResponse.From)
                    .ToList();

            return new ListCampaignBookingsResponse(response);
        }

        public class BookingResponse
        {
            public string FaceId { get; }

            public BookingResponse(string faceId)
            {
                FaceId = faceId;
            }

            public static BookingResponse From(GetBookingsByCampaignResult.Booking booking)
            {
                return new BookingResponse(booking.FaceId.ToString());
            }
        }
    }
}