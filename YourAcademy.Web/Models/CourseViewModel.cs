using YourAcademy.DAL.Entity;
using YourAcademy.Services.Interface;

namespace YourAcademy.Web.Models
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public string? Instructor { get; set; }
        public string? Image { get; set; }
        public decimal Rating { get; set; }
        public readonly ICourseService _service;

        public CourseViewModel()
        { }
        public CourseViewModel(ICourseService service)
        {
            _service = service;
        }

        public IList<Course> GetCourses()
        {
            return _service.GetAllCourses();
        }

    }
}
