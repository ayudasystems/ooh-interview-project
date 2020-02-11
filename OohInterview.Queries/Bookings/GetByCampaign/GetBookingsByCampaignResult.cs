using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace OohInterview.Queries.Bookings.GetByCampaign
{
    public class GetBookingsByCampaignResult
    {
        public IReadOnlyCollection<Booking> Bookings { get; }

        public GetBookingsByCampaignResult(IEnumerable<Booking> bookings)
        {
            Bookings = bookings.ToImmutableList();
        }

        public class Booking
        {
            public Guid FaceId { get; }

            public Booking(Guid faceId)
            {
                if (faceId == Guid.Empty)
                    throw new ArgumentException($"{nameof(Booking)} {nameof(FaceId)}");

                FaceId = faceId;
            }
        }
    }
}