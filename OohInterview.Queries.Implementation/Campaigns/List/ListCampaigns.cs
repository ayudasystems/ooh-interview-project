using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OohInterview.DAL.Repositories;
using OohInterview.Queries.Campaigns.List;

namespace OohInterview.Queries.Implementation.Campaigns.List
{
    public class ListCampaigns : IListCampaigns
    {
        private readonly ICampaignRepository _campaignRepository;

        public ListCampaigns(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        
        public ListCampaignsResult List(CancellationToken cancellationToken)
        {
            var campaignPocos = _campaignRepository.GetCampaigns();
            var campaigns = campaignPocos.Select(c => 
                new ListCampaignsResult.Campaign(
                    c.Id,
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    c.Faces.Select(f => new ListCampaignsResult.Face(f.Id)))
            );
            return new ListCampaignsResult(campaigns);
        }
    }
}