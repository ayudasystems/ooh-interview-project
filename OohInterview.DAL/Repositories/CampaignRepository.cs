using System.Collections.Generic;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Repositories
{
    public class CampaignRepository: ICampaignRepository
    {
        private readonly DataContext _dataContext;

        public CampaignRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public IEnumerable<Campaign> GetCampaigns()
        {
            return _dataContext.Campaigns;
        }

        public void AddCampaign(Campaign campaign)
        {
            //TODO: make sure the faces inside the campaign actually exists
            _dataContext.Campaigns.Add(campaign);
        }
    }
}