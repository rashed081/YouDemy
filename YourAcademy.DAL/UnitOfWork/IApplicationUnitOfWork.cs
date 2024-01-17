using YourAcademy.DAL.RepositoryInterface;

namespace YourAcademy.DAL.UnitOfWork
{
    public interface IApplicationUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        ICategoryRepository Categories { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
