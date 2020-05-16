using NotificationCenter.DataAccess.Repositories;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess
{
    public interface IUnitOfWork
    {
        INotificationRepository NotificationRepository { get; }

        ICertificateRepository CertificateRespoitory { get; }

        IRequestRepository RequestRepository { get; }

        INotificationEventRepository NotificationEventRepository { get; }

        Task Commit();

        ValueTask Rollback();
    }
}