using Autofac;
using Microsoft.AspNetCore.Mvc.Rendering;
using YourAcademy.DAL.Entity;
using YourAcademy.DAL.Enums;
using YourAcademy.Services.Interface;

namespace YourAcademy.Web.Models
{
    public class CourseCreateModel
    {
        
        public string CategoryId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }   
        public float Price { get; set; }
        public string? Instructor { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public string? Image { get; set; }
        public decimal Rating { get; set; }
        
        private ICourseService _courseService;
        private ICategoryService _categoryService;
        public CourseCreateModel()
        {

        }

        public CourseCreateModel(ICourseService courseService, ICategoryService categoryService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _courseService = scope.Resolve<ICourseService>();
            _categoryService = scope.Resolve<ICategoryService>();
        }
        public IEnumerable<SelectListItem> Categories;
        public void LoadCategories()
        {
            var categories = _categoryService.GetAllCategoriess();
            Categories = categories.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }) ?? Enumerable.Empty<SelectListItem>();
        }
                
        internal void CreateCourse()
        {
            if (!string.IsNullOrWhiteSpace(Title)
                && Price >= 0)
            {
                var courseToAdd = new Course
                {
                    Title = this.Title,
                    Price = this.Price,
                    Instructor = this.Instructor,
                    Image = this.Image,
                    Rating = this.Rating,
                    Description = this.Description,
                    CategoryId = this.CategoryId,
                    DifficultyLevel = this.DifficultyLevel
                };
                _courseService.AddCourse(courseToAdd);
            }
        }
    }
}
