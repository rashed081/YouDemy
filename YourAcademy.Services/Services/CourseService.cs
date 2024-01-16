using YourAcademy.DAL.Entity;
using YourAcademy.DAL.UnitOfWork;
using YourAcademy.Services.Interface;

namespace YourAcademy.Services.Services
{
    public class CourseService :ICourseService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public CourseService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCourse(Course course)
        {
            try
            {
                _unitOfWork.Courses.Add(course);
            }
            catch (Exception)
            {
               throw;
            }
        }

        public IList<Course> GetAllCourses()
        {
            try
            {
                var courses = _unitOfWork.Courses.GetAll();

                return courses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Course GetCourse(Guid id)
        {
            try
            {
                var course = _unitOfWork.Courses.GetById(id);
                return course;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
