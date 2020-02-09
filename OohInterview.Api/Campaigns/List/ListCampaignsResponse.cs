using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using OohInterview.Api.Common.Responses;
using OohInterview.Queries.Campaigns.List;

namespace OohInterview.Api.Campaigns.List
{
    public class ListCampaignsResponse : CollectionResponse<ListCampaignsResponse.CampaignResponse>
    {
        public ListCampaignsResponse(List<CampaignResponse> items)
            : base(items)
        {
        }

        public static ListCampaignsResponse FromQuery(ListCampaignsResult result)
        {
            var response =
                result.Campaigns
                    .Select(CampaignResponse.From)
                    .ToList();

            return new ListCampaignsResponse(response);
        }

        public class CampaignResponse
        {
            public string Id { get; }
            public string Name { get; }
            public DateTime StartDate { get; }
            public DateTime EndDate { get; }
            public IReadOnlyCollection<FaceResponse> Faces { get; set; }

            public CampaignResponse(string id, string name, DateTime startDate, DateTime endDate, IEnumerable<ListCampaignsResult.Face> faces)
            {
                Id = id;
                Name = name;
                StartDate = startDate;
                EndDate = endDate;
                Faces = faces.Select(FaceResponse.From).ToImmutableList();
            }

            public static CampaignResponse From(ListCampaignsResult.Campaign campaign)
            {
                return new CampaignResponse(
                    campaign.Id.ToString(),
                    campaign.Name,
                    campaign.StartDate,
                    campaign.EndDate,
                    campaign.Faces
                );
            }
        }
        
        public class FaceResponse
        {
            public string Id { get; }

            public FaceResponse(string id)
            {
                Id = id;
            }

            public static FaceResponse From(ListCampaignsResult.Face face)
            {
                return new FaceResponse(
                    face.Id.ToString()
                );
            }
        }
    }
}