using YourAcademy.DAL.Entity;
using YourAcademy.DAL.UnitOfWork;
using YourAcademy.Services.Interface;

namespace YourAcademy.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public CategoryService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCategory(Category Category)
        {
            try
            {
                _unitOfWork.Categories.Add(Category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IList<Category> GetAllCategoriess()
        {
            try
            {
                var categories = _unitOfWork.Categories.GetAll();

                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Category GetCategory(Guid id)
        {
            try
            {
                var Category = _unitOfWork.Categories.GetById(id);
                return Category;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
