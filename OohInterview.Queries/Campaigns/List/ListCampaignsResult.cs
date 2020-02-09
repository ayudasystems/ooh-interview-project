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
            public IReadOnlyCollection<Face> Faces { get; }
            
            public Campaign(Guid id, string name, DateTime startDate, DateTime endDate, IEnumerable<Face> faces)
            {
                if (id == Guid.Empty)
                    throw new ArgumentException($"{nameof(Campaign)} {nameof(Id)}");

                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException($"{nameof(Campaign)} {nameof(Name)}");

                Id = id;
                Name = name;
                StartDate = startDate;
                EndDate = endDate;
                Faces = faces.ToImmutableList();
            }
        }

        public class Face
        {
            public Guid Id { get; }

            public Face(Guid id)
            {
                Id = id;
            }
        }
    }
}