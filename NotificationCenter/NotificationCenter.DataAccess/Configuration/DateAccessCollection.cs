using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationCenter.DataAccess.Entities;
using NotificationCenter.EventBroker.Configuration;

namespace NotificationCenter.DataAccess.Configuration
{
    public static class DateAccessCollection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<NotificationCenterContext>();

            services.AddEventBroker(configuration);

            return services;
        }
    }
}
