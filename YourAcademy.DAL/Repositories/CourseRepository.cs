using NHibernate;
using YourAcademy.DAL.Entity;
using YourAcademy.DAL.RepositoryInterface;

namespace YourAcademy.DAL.Repositories
{
    public class CourseRepository : Repository<Course, Guid>, ICourseRepository
    {
      public CourseRepository(INHibernateHelper nHibernateHelper) :base(nHibernateHelper) { }
        
    }
}
