using YourAcademy.DAL.Entity;

namespace YourAcademy.Services.Interface
{
    public interface ICategoryService
    {
        void AddCategory(Category Category);
        IList<Category> GetAllCategoriess();
        Category GetCategory(Guid id);
    }
}