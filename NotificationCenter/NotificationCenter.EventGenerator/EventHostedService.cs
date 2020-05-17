using Microsoft.Extensions.Hosting;
using NotificationCenter.Core.Events;
using NotificationCenter.EventBroker;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationCenter.EventGenerator
{
    public class EventHostedService : IHostedService, IDisposable
    {
        private readonly IEnumerable<IEventGenerator> _eventGenerators;
        private readonly IEventBroker _eventBroker;

        private Timer _timer;

        public EventHostedService(
            IEventBroker eventBroker,
            IEnumerable<IEventGenerator> eventGenerators)
        {
            _eventBroker = eventBroker;
            _eventGenerators = eventGenerators;
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
                foreach (var generator in _eventGenerators)
                {
                    IEnumerable<CertificateExpirationEvent> events = await generator.GenerateAsync();
                    _eventBroker.EventsOccured(events);
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
