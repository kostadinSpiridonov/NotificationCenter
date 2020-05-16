using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationCenter.SignalR.Configuration;

namespace NotificationCenter.Core.Configuration
{
    public static class CoreCollection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotificationEventHandler, NotificationEventHandler>();
            services.AddTransient<INotificationProcessor, NotificationProcessor>();

            return services;
        }
    }
}
