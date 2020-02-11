using Microsoft.Extensions.DependencyInjection;
using OohInterview.DAL;
using OohInterview.DAL.Repositories;

namespace OohInterview.DependencyInjection
{
    public static class Database
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            return services
                .RegisterRepositories()
                .AddSingleton<DataContext, DataContext>();
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IBookingRepository, BookingRepository>()
                .AddScoped<ICampaignRepository, CampaignRepository>()
                .AddScoped<IFaceRepository, FaceRepository>();
        }
    }
}