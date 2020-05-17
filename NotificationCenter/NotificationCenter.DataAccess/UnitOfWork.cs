using NotificationCenter.DataAccess.Repositories;
using System.Threading.Tasks;

namespace NotificationCenter.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        public INotificationRepository NotificationRepository { get; private set; }

        public ICertificateRepository CertificateRespoitory { get; private set; }

        public IRequestRepository RequestRepository { get; private set; }

        public INotificationEventRepository NotificationEventRepository { get; private set; }

        public ILoginRepository LoginRepository { get; private set; }

        private readonly ExtendedNotificationCenterContext _databaseContext;

        public UnitOfWork(ExtendedNotificationCenterContext databaseContext)
        {
            NotificationRepository = new NotificationRepository(databaseContext);
            CertificateRespoitory = new CertificateRepository(databaseContext);
            RequestRepository = new RequestRepository(databaseContext);
            NotificationEventRepository = new NotificationEventRepository(databaseContext);
            LoginRepository = new LoginRepository(databaseContext);

            _databaseContext = databaseContext;
        }

        public Task Commit()
        {
            return _databaseContext.SaveChangesAsync();
        }

        public ValueTask Rollback()
        {
            return _databaseContext.DisposeAsync();
        }
    }
}
