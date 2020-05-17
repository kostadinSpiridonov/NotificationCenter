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

        public IClientRepository ClientRepository { get; private set; }

        private readonly ExtendedNotificationCenterContext _databaseContext;

        public UnitOfWork(ExtendedNotificationCenterContext databaseContext)
        {
            NotificationRepository = new NotificationRepository(databaseContext);
            CertificateRespoitory = new CertificateRepository(databaseContext);
            RequestRepository = new RequestRepository(databaseContext);
            NotificationEventRepository = new NotificationEventRepository(databaseContext);
            LoginRepository = new LoginRepository(databaseContext);
            ClientRepository = new ClientRepository(databaseContext);

            _databaseContext = databaseContext;
        }

        public Task CommitAsync()
        {
            return _databaseContext.SaveChangesAsync();
        }

        public ValueTask RollbackAsync()
        {
            return _databaseContext.DisposeAsync();
        }
    }
}
