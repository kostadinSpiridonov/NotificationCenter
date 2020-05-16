using NotificationCenter.Core.Events;
using System.Threading.Tasks;

namespace NotificationCenter.Core
{
    public interface INotificationProcessor
    {
        Task Process(BaseEvent eventMessage);
    }
}
