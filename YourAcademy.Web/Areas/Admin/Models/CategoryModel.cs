using Autofac;
using System.ComponentModel.DataAnnotations;
using YourAcademy.DAL.Entity;
using YourAcademy.Services.Interface;

namespace YourAcademy.Web.Areas.Admin.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        [Required]
        public string? Title { get; set; }

        public IEnumerable<Category> Categories;
        private ICategoryService _categoryService;

        public CategoryModel(){}

        public CategoryModel(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _categoryService = scope.Resolve<ICategoryService>();
        }

        public void LoadCategories()
        {
            Categories = _categoryService.GetAllCategoriess();
        }

        public void CreateCatagory()
        {
            if (!string.IsNullOrWhiteSpace(Title))
            {
                var categoryToAdd = new Category
                {
                    Title = Title
                };
                _categoryService.AddCategory(categoryToAdd);
            }
        }
    }
}
