using Microsoft.Extensions.DependencyInjection;

namespace OohInterview.DependencyInjection
{
    public static class Database
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            return services
                .RegisterRepositories();
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}