using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationCenter.DataAccess.ChangeProcessors;
using NotificationCenter.DataAccess.Entities;
using NotificationCenter.EventBroker.Configuration;
using System;
using System.Collections.Generic;

namespace NotificationCenter.DataAccess.Configuration
{
    public static class DateAccessCollection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ExtendedNotificationCenterContext>();
            services.AddTransient<RequestChangeProcessor>();

            services.AddTransient(
                typeof(IDictionary<Type, IChangeProcessor>),
                x => new Dictionary<Type, IChangeProcessor>
                {
                    {typeof(Request), x.GetService<RequestChangeProcessor>() }
                });

            services.AddEventBroker(configuration);

            return services;
        }
    }
}
