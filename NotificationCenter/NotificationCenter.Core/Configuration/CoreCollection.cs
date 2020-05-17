using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationCenter.Core.Managers;

namespace NotificationCenter.Core.Configuration
{
    public static class CoreCollection
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotificationEventHandler, NotificationEventHandler>();
            services.AddTransient<INotificationProcessor, NotificationProcessor>();
            services.AddTransient<INotificationManager, WebNotificationManager>();
            services.AddTransient<INotificationManager, DatabaseNotificationManager>();

            return services;
        }
    }
}
