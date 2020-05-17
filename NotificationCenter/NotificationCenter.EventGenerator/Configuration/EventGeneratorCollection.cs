using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationCenter.EventGenerator.Configuration
{
    public static class EventGeneratorCollection
    {
        public static IServiceCollection AddEventGenerator(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<NotificatioHostedService>();
            services.AddTransient<INotificationGenerator, CertificateNotificationGenerator>();

            return services;
        }
    }
}
