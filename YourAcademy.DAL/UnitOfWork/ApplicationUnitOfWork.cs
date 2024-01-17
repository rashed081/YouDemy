using NHibernate;
using YourAcademy.DAL.RepositoryInterface;

namespace YourAcademy.DAL.UnitOfWork
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction? _transaction;

        public ICourseRepository Courses { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public ApplicationUnitOfWork(ISession session, ICourseRepository course, ICategoryRepository categories)
        {
            _session = session;
            Courses = course;
            Categories = categories;

        }
        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction != null && _transaction.IsActive)
            {
                _transaction.Commit();
            }
        }

        public void Rollback()
        {
            if (_transaction != null && _transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }

        public void Dispose()
        {
            if (_transaction != null && _transaction.IsActive)
            {
                _transaction.Rollback();
            }

            _transaction?.Dispose();
            _session?.Dispose();
        }
    }
}
