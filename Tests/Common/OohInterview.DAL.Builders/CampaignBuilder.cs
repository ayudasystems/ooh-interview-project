using System;
using System.Collections.Generic;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Builders
{
    public class CampaignBuilder
    {
        private const string DefaultName = "campaign name";

        private Guid _id;
        private string _name;
        private DateTime _startDate;
        private DateTime _endDate;
        private List<Guid> _bookedFaceIds;

        public CampaignBuilder()
        {
            _id = Guid.NewGuid();
            _name = DefaultName;
            _startDate = new DateTime(2020, 01, 17);
            _endDate = _startDate.AddDays(28);
            _bookedFaceIds = new List<Guid>();
        }

        public CampaignBuilder WithId(Guid campaignId)
        {
            _id = campaignId;
            return this;
        }

        public CampaignBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CampaignBuilder WithStartDate(DateTime startDate)
        {
            _startDate = startDate;
            return this;
        }

        public CampaignBuilder WithEndDate(DateTime endDate)
        {
            _endDate = endDate;
            return this;
        }

        public CampaignBuilder AddBooking(Guid faceId)
        {
            _bookedFaceIds.Add(faceId);
            return this;
        }

        public Campaign Build()
        {
            return new Campaign()
            {
                Id = _id,
                Name = _name,
                StartDate = _startDate,
                EndDate = _endDate
            };
        }

        public Campaign BuildAndAddToContext(DataContext context)
        {
            var poco = Build();
            context.Campaigns.Add(poco);

            return poco;
        }
    }
}