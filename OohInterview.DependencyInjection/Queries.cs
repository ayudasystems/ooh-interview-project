using Microsoft.Extensions.DependencyInjection;
using OohInterview.Queries.Campaigns.List;
using OohInterview.Queries.Faces.List;
using OohInterview.Queries.Implementation.Campaigns.List;
using OohInterview.Queries.Implementation.Faces.List;

namespace OohInterview.DependencyInjection
{
    public static class Queries
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            return services
                .AddScoped<IListCampaigns, ListCampaigns>()
                .AddScoped<IListFaces, ListFaces>();
        }
    }
}