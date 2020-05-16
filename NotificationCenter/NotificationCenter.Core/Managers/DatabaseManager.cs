using NotificationCenter.Core.Models;
using NotificationCenter.DataAccess;
using NotificationCenter.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.Core.Managers
{
    public class DatabaseManager : INotificationManager
    {
        public string Type { get; set; } = "Database";

        private readonly IUnitOfWork _unitOfWork;

        public DatabaseManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Send(IEnumerable<NotificationModel> notifications, IEnumerable<string> users)
        {
            foreach (var notification in notifications)
            {
                await _unitOfWork.NotificationRepository.Save(new Notification() { Content = notification.Content, ClientId = notification.ClientId });
            }

            await _unitOfWork.Commit();
        }
    }
}
