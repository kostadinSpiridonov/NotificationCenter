using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationCenter.EventBroker.Configuration
{
    public static class EventBrokerCollection
    {
        public static IServiceCollection AddEventBroker(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEventBroker, EventBroker>();

            return services;
        }
    }
}
