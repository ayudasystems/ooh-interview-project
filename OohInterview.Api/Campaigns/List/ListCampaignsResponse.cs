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

            public CampaignResponse(string id, string name, DateTime startDate, DateTime endDate)
            {
                Id = id;
                Name = name;
                StartDate = startDate;
                EndDate = endDate;
            }

            public static CampaignResponse From(ListCampaignsResult.Campaign campaign)
            {
                return new CampaignResponse(
                    campaign.Id.ToString(),
                    campaign.Name,
                    campaign.StartDate,
                    campaign.EndDate
                );
            }
        }
    }
}