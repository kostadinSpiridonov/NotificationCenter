using NotificationCenter.Core.Events;
using NotificationCenter.Core.Managers;
using NotificationCenter.Core.Models;
using NotificationCenter.DataAccess;
using NotificationCenter.DataAccess.Entities;
using NotificationCenter.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.Core
{
    internal class NotificationProcessor : INotificationProcessor
    {
        public IEnumerable<INotificationManager> _notificationManagers;
        public IUnitOfWork _unitOfWork;

        public NotificationProcessor(IUnitOfWork unitOfWork, INotificationService notificationHub)
        {
            _unitOfWork = unitOfWork;
            _notificationManagers = new List<INotificationManager>
            {
                new WebManager(notificationHub),
                new DatabaseManager(_unitOfWork)
            };
        }

        public async Task Process(BaseEvent eventMessage)
        {
            var notificationEvents = await _unitOfWork.NotificationEventRepository.GetAllByType(eventMessage.Type);


            foreach (var notificationEvent in notificationEvents)
            {
                var message = new NotificationModel()
                {
                    Content = BuildMessage(notificationEvent, eventMessage)
                };

                var channels = notificationEvent.NotificationEventChannels.Select(x => x.NotificationChannel.Name).ToList();

                var tasks = _notificationManagers
                    .Where(x => x.Type == "Database" || channels.Contains(x.Type))
                    .Select(x => x.Send(new List<NotificationModel> { message }));
               
                await Task.WhenAll(tasks);
            }
        }

        private string BuildMessage(NotificationEvent notificationEvent, BaseEvent baseEvent)
        {
            switch (baseEvent)
            {
                case CertificateExpirationEvent certificateExpirationEvent:
                    {
                        return string.Format(
                            notificationEvent.Criteria.Template,
                            certificateExpirationEvent.StartDate,
                            certificateExpirationEvent.EndDate,
                            certificateExpirationEvent.SerialNumber);
                    }
                case RequestStatusChangeEvent requestStatusChangeEvent:
                    {
                        return string.Format(
                            notificationEvent.Criteria.Template,
                            requestStatusChangeEvent.RequestType,
                            requestStatusChangeEvent.RequestStatus);
                    }
            }

            return null;
        }
    }
}
