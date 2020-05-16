using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationCenter.SignalR.Configuration
{
    public static class WebSignalRCollection
    {
        public static IServiceCollection AddWebSignalR(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<INotificationHub, NotificationHub>();
            services.AddTransient<INotificationService, NotificationService>();

            return services;
        }
    }
}
