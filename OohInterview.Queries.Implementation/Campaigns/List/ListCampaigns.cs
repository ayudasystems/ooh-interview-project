using System.Collections.Generic;
using System.Threading;
using OohInterview.Queries.Campaigns.List;

namespace OohInterview.Queries.Implementation.Campaigns.List
{
    public class ListCampaigns : IListCampaigns
    {
        public ListCampaignsResult List(CancellationToken cancellationToken)
        {
            return new ListCampaignsResult(new List<ListCampaignsResult.Campaign>());
        }
    }
}