using YourAcademy.DAL.Entity;

namespace YourAcademy.DAL.RepositoryInterface
{
    public interface ICategoryRepository:IRepository<Category, Guid>
    {
    }
}