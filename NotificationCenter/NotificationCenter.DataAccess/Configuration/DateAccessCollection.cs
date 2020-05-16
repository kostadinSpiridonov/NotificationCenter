using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationCenter.DataAccess.Entities;
using NotificationCenter.DataAccess.Repositories;
using NotificationCenter.EventBroker.Configuration;

namespace NotificationCenter.DataAccess.Configuration
{
    public static class DateAccessCollection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICertificateRepository, CertificateRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<INotificationEventRepository, NotificationEventRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<NotificationCenterContext>();

            services.AddEventBroker(configuration);

            return services;
        }
    }
}
