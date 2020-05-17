using NotificationCenter.DataAccess;
using NotificationCenter.DataAccess.Entities;
using NotificationCenter.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.Web.Services
{
    internal class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<NotificationViewModel>> GetAllAsync(int clientId)
        {
            IEnumerable<Notification> notifications = await _unitOfWork.NotificationRepository.GetByClientIdAsync(clientId);

            // TODO: Use automapper
            return notifications.Select(x => new NotificationViewModel
            {
                Content = x.Content
            });
        }

        public async Task SimulateRequestUpdateAsync()
        {
            IEnumerable<Request> notifications = await _unitOfWork.RequestRepository.GetAll();

            Request firstNotification = notifications.First();
            firstNotification.Status = "change";
            await _unitOfWork.RequestRepository.UpdateAsync(firstNotification);

            await _unitOfWork.CommitAsync();
        }
    }
}
