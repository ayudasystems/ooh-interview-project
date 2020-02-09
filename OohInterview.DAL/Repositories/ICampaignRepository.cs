using System.Collections.Generic;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Repositories
{
    public interface ICampaignRepository
    {
        IEnumerable<Campaign> GetCampaigns();
        void AddCampaign(Campaign campaign);
    }
}