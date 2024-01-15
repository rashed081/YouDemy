using YourAcademy.DAL.Entity;

namespace YourAcademy.Services.Interface
{
    public interface ICourseService
    {
        List<Course> GetCourses();
        Course GetCourse(int id);
    }
}
