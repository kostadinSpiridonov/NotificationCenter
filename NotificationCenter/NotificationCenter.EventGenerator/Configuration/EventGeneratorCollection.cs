using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationCenter.EventGenerator.Configuration
{
      public static class EventGeneratorCollection
    {
        public static IServiceCollection AddEventBroker(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
