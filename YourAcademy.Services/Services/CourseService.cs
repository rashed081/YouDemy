using YourAcademy.DAL;
using YourAcademy.DAL.Entity;
using YourAcademy.Services.Interface;

namespace YourAcademy.Services.Services
{
    public class CourseService : ICourseService
    {
        public Course GetCourse(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<Course>(id);
            }
        }

        public List<Course> GetCourses()
        {
            throw new NotImplementedException();
        }
    }
}
