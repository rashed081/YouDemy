using Autofac;
using System.ComponentModel.DataAnnotations;
using YourAcademy.DAL.Entity;
using YourAcademy.Services.Interface;

namespace YourAcademy.Web.Models
{
    public class CourseCreateModel
    {
        [Required]
        public virtual string? Title { get; set; }
        public virtual string? Description { get; set; }
        [Required, Range(0, 50000, ErrorMessage = "Fees should be between 0 & 50000")]
        public virtual float Price { get; set; }
        public virtual string? Instructor { get; set; }
        public virtual string? Image { get; set; }
        public virtual decimal Rating { get; set; }
        

        private ICourseService _courseService;

        public CourseCreateModel()
        {

        }

        public CourseCreateModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _courseService = scope.Resolve<ICourseService>();
        }
        internal void CreateCourse()
        {
            if (!string.IsNullOrWhiteSpace(Title)
                && Price >= 0)
            {
                var courseToAdd = new Course 
                { 
                    Title = this.Title , 
                    Price  = this.Price,
                    Instructor = this.Instructor ,
                    Image = this.Image ,
                    Rating = this.Rating ,
                };
                _courseService.AddCourse(courseToAdd);
            }
        }
    }
}
