using YourAcademy.DAL.Entity;

namespace YourAcademy.DAL.RepositoryInterface
{
    public interface ICourseRepository :IRepository<Course, Guid>
    {
    }
}
