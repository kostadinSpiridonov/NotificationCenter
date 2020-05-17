using NotificationCenter.Core.Events;
using NotificationCenter.Core.Managers;
using NotificationCenter.Core.Models;
using NotificationCenter.DataAccess;
using NotificationCenter.DataAccess.Entities;
using NotificationCenter.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.Core
{
    internal class NotificationProcessor : INotificationProcessor
    {
        public IEnumerable<INotificationManager> _notificationManagers;
        public IUnitOfWork _unitOfWork;

        public NotificationProcessor(IUnitOfWork unitOfWork, ISignalRNotificationService notificationHub)
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
            var notificationEvents = await _unitOfWork.NotificationEventRepository.GetAllByType((NotificationCrieriaType)eventMessage.Type);


            foreach (var notificationEvent in notificationEvents)
            {
                var message = new NotificationModel()
                {
                    Content = BuildMessage(notificationEvent, eventMessage),
                    ClientId = eventMessage.ClientId
                };

                var channels = notificationEvent.NotificationEventChannels.Select(x => x.NotificationChannel.Type).ToList();
                var clientTypes = notificationEvent.NotificationsEventClientTypes.Select(x => x.ClientType.Name);
                var users = await _unitOfWork.LoginRepository.GetByClientIdAsync(eventMessage.ClientId, clientTypes);
                var tasks = _notificationManagers
                    .Where(x => channels.Contains(x.ChannelType))
                    .Select(x => x.Send(new List<NotificationModel> { message }, users.Select(x => x.Username)));

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
