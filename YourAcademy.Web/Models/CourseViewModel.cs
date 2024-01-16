using YourAcademy.DAL.Entity;
using YourAcademy.Services.Interface;

namespace YourAcademy.Web.Models
{
    public class CourseViewModel
    {
        public IEnumerable<Course> Courses { get; set; }

        private readonly ICourseService _service;


        public CourseViewModel(ICourseService service)
        {
            _service = service;
        }

        public CourseViewModel()
        {
        }

        public void LoadCourses()
        {
            Courses = _service.GetAllCourses();
        }

    }
}
