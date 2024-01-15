using YourAcademy.DAL;
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
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void AddCourse(Course course)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.Courses.Add(course);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
