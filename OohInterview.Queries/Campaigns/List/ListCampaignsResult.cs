using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace OohInterview.Queries.Campaigns.List
{
    public class ListCampaignsResult
    {
        public IReadOnlyCollection<Campaign> Campaigns { get; }

        public ListCampaignsResult(IEnumerable<Campaign> campaigns)
        {
            Campaigns = campaigns.ToImmutableList();
        }

        public class Campaign
        {
            public Guid Id { get; }
            public DateTime StartDate { get; }
            public DateTime EndDate { get; }
            public string Name { get; }

            public Campaign(Guid id, string name, DateTime startDate, DateTime endDate)
            {
                if (id == Guid.Empty)
                    throw new ArgumentException($"{nameof(Campaign)} {nameof(Id)}");

                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException($"{nameof(Campaign)} {nameof(Name)}");

                if (endDate < startDate)
                    throw new ArgumentException("The Start Date must be before the End Date");

                Id = id;
                Name = name;
                StartDate = startDate;
                EndDate = endDate;
            }
        }
    }
}