using YourAcademy.DAL.Entity;

namespace YourAcademy.Services.Interface
{
    public interface ICourseService
    {

        void AddCourse(Course course);
        IList<Course> GetAllCourses();
    }
}
