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
            var firstFace = new Face
            {
                Id = Guid.NewGuid(),
                Name = "First face",
                RatePerDay = 5212.67m
            };
            
            var secondFace = new Face
            {
                Id = Guid.NewGuid(),
                Name = "Second face",
                RatePerDay = 4572.12m
            };
            
            var availableFace = new Face
            {
                Id = Guid.NewGuid(),
                Name = "Available face",
                RatePerDay = 123.45m
            };

            var firstCampaign = new Campaign
            {
                Id = Guid.NewGuid(),
                Name = "First Campaign",
                StartDate = new DateTime(2019, 1, 1),
                EndDate = new DateTime(2019, 12, 31),
            };
            
            var campaignWith2Bookings = new Campaign
            {
                Id = Guid.NewGuid(),
                Name = "Campaign with 2 bookings",
                StartDate = new DateTime(2020, 1, 1),
                EndDate = new DateTime(2020, 10, 31),
            };

            var booking1 = new Booking
            {
                CampaignId = firstCampaign.Id,
                FaceId = firstFace.Id
            };

            var booking2 = new Booking
            {
                CampaignId = campaignWith2Bookings.Id,
                FaceId = firstFace.Id
            };

            var booking3 = new Booking
            {
                CampaignId = campaignWith2Bookings.Id,
                FaceId = secondFace.Id
            };
            

            Faces.Add(firstFace);
            Faces.Add(secondFace);
            Faces.Add(availableFace);
            Campaigns.Add(firstCampaign);
            Campaigns.Add(campaignWith2Bookings);
            Bookings.Add(booking1);
            Bookings.Add(booking2);
            Bookings.Add(booking3);
        }
    }
}