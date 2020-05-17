using Microsoft.Extensions.Hosting;
using NotificationCenter.EventBroker;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationCenter.EventGenerator
{
    public class NotificatioHostedService : IHostedService, IDisposable
    {
        private readonly IEnumerable<INotificationGenerator> _notificationGenerators;
        private readonly IEventBroker _notificationEventBroker;

        private Timer _timer;

        public NotificatioHostedService(
            IEventBroker notificationEventBroker,
            IEnumerable<INotificationGenerator> notificationGenerators)
        {
            _notificationEventBroker = notificationEventBroker;
            _notificationGenerators = notificationGenerators;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            DoWorkAsync(state).Wait();
        }

        private async Task DoWorkAsync(object state)
        {
            try
            {
                foreach (var generator in _notificationGenerators)
                {
                    IEnumerable<Core.Events.CertificateExpirationEvent> messages = await generator.Generate();
                    _notificationEventBroker.OnEventsOccured(messages);
                }
            }
            catch (Exception e)
            {
                // TODO: Log
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
