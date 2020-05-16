using Microsoft.Extensions.Hosting;
using NotificationCenter.Core.Events;
using NotificationCenter.DataAccess;
using NotificationCenter.EventBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationCenter.EventGenerator
{
    public class NotificatioHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private Timer _timer;
        private readonly IEnumerable<INotificationGenerator> _notificationGenerators;
        private readonly IEventBroker _notificationEventBroker;

        public NotificatioHostedService(IEventBroker notificationEventBroker, IUnitOfWork unitOfWork)
        {
            _notificationEventBroker = notificationEventBroker;
            _notificationGenerators = new List<INotificationGenerator>()
            {
                new CertificateNotificationGenerator(unitOfWork)
            };
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            DoWorkAsync(state).Wait();
        }

        private async Task DoWorkAsync(object state)
        {
            var count = Interlocked.Increment(ref executionCount);

            foreach (var generator in _notificationGenerators)
            {
                foreach (var message in await generator.Generate())
                {
                    _notificationEventBroker.OnEventOccured(message);
                }
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
