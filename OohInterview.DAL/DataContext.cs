using System;
using System.Collections.Generic;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL
{
    public class DataContext
    {
        public IList<Face> Faces { get; protected set; }

        public IList<Campaign> Campaigns { get; protected set; }
        public IList<Booking> Bookings { get; protected set; }

        public DataContext(bool seedData = true)
        {
            Faces = new List<Face>();
            Campaigns = new List<Campaign>();
            Bookings = new List<Booking>();

            if (seedData)
                InitializeData();
        }

        private void InitializeData()
        {
            var firstFace = new Face()
            {
                Id = Guid.NewGuid(),
                Name = "First face",
                RatePerDay = 5212.67m
            };

            var firstCampaign = new Campaign
            {
                Id = Guid.NewGuid(),
                Name = "First Campaign",
                StartDate = new DateTime(2019, 1, 1),
                EndDate = new DateTime(2019, 12, 31),
            };

            var firstBooking = new Booking()
            {
                CampaignId = firstCampaign.Id,
                FaceId = firstFace.Id
            };

            Faces.Add(firstFace);
            Campaigns.Add(firstCampaign);
            Bookings.Add(firstBooking);
        }
    }
}