using NotificationCenter.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationCenter.Web.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationViewModel>> GetAllAsync(int clientId);
        
        Task SimulateRequestUpdateAsync();
    }
}
