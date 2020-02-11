using System.Linq;
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

        public ListCampaignsResult List()
        {
            var campaignPocos = _campaignRepository.GetCampaigns();
            var campaigns = campaignPocos.Select(
                c =>
                    new ListCampaignsResult.Campaign(
                        c.Id,
                        c.Name,
                        c.StartDate,
                        c.EndDate
                    ));
            return new ListCampaignsResult(campaigns);
        }
    }
}