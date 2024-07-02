using Microsoft.Extensions.DependencyInjection;

namespace TimeLogger.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTimeLoggerApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
            return services;
        }
    }
}
