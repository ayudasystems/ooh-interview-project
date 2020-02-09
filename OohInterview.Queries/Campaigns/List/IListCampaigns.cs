using System.Threading;
using System.Threading.Tasks;

namespace OohInterview.Queries.Campaigns.List
{
    public interface IListCampaigns
    {
        ListCampaignsResult List(CancellationToken cancellationToken);
    }
}