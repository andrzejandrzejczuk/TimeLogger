using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TimeLogger.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTimeLoggerInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
