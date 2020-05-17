using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationCenter.SignalR.Configuration
{
    public static class WebSignalRCollection
    {
        public static IServiceCollection AddWebSignalR(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISignalRNotificationService, SignalRNotificationService>();

            return services;
        }
    }
}
