using YourAcademy.DAL.Entity;
using YourAcademy.DAL.RepositoryInterface;

namespace YourAcademy.DAL.Repositories
{
    public class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(INHibernateHelper nHibernateHelper) : base(nHibernateHelper) { }

    }
}
