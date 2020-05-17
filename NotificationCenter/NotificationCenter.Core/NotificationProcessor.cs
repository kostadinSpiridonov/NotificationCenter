using NotificationCenter.Core.Events;
using NotificationCenter.Core.Models;
using NotificationCenter.DataAccess;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.Core
{
    internal class NotificationProcessor : INotificationProcessor
    {
        public IEnumerable<INotificationManager> _notificationManagers;
        public IUnitOfWork _unitOfWork;

        public NotificationProcessor(IEnumerable<INotificationManager> notificationManagers, IUnitOfWork unitOfWork)
        {
            _notificationManagers = notificationManagers;
            _unitOfWork = unitOfWork;
        }

        public async Task ProcessAsync(BaseEvent baseEvent)
        {
            Client client = await _unitOfWork.ClientRepository.GetById(baseEvent.ClientId);

            IEnumerable<NotificationEvent> notificationEvents = await _unitOfWork.NotificationEventRepository
                .GetAllByTypeAsync((NotificationCrieriaType)baseEvent.Type, client.ClientTypeId);

            IEnumerable<NotificationModel> notifications = notificationEvents
                .Select(x => BuildNotificationAsync(client, baseEvent, x));

            foreach (var notificationManager in _notificationManagers)
            {
                var channelNotifications = notifications.Where(x => x.Channels.Contains(notificationManager.ChannelType));
                await notificationManager.SendAsync(channelNotifications);
            }
        }

        private NotificationModel BuildNotificationAsync(Client client, BaseEvent baseEvent, NotificationEvent notificationEvent)
        {
            IEnumerable<NotificationChannelTypeModel> channels = notificationEvent.NotificationEventChannels
                   .Select(x => (NotificationChannelTypeModel)x.NotificationChannel.Type);

            return new NotificationModel
            {
                Content = BuildNotifiationContent(notificationEvent, baseEvent),
                ClientId = baseEvent.ClientId,
                Usernames = client.Logins.Select(x => x.Username),
                Channels = channels
            };
        }

        private string BuildNotifiationContent(NotificationEvent notificationEvent, BaseEvent baseEvent)
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
