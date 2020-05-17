using NotificationCenter.Core.Models;
using NotificationCenter.DataAccess;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.Core.Managers
{
    internal class DatabaseNotificationManager : INotificationManager
    {
        public NotificationChannelTypeModel ChannelType { get; } = NotificationChannelTypeModel.Database;

        private readonly IUnitOfWork _unitOfWork;

        public DatabaseNotificationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SendAsync(IEnumerable<NotificationModel> notifications)
        {
            // TODO: Use automapper
            var mappedNotifications = notifications.Select(x => new Notification
            {
                Content = x.Content,
                ClientId = x.ClientId
            });

            await _unitOfWork.NotificationRepository.SaveAsync(mappedNotifications);
            await _unitOfWork.CommitAsync();
        }
    }
}
