using YourAcademy.DAL.Entity;

namespace YourAcademy.DAL.RepositoryInterface
{
    public interface IRepository<TEntity, TKey> where TKey : IComparable
    where TEntity : class, IEntity<TKey>
    {
        void Add(TEntity entity);
        void Remove(TKey id);
        void Remove(TEntity entity);
        void Edit(TEntity entityToUpdate);
        TEntity GetById(TKey id);
        IList<TEntity> GetAll();
    }
}
