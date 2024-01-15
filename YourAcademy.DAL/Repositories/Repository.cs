using NHibernate;
using YourAcademy.DAL.Entity;
using YourAcademy.DAL.RepositoryInterface;

namespace YourAcademy.DAL.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TKey : IComparable
    where TEntity : class, IEntity<TKey>
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public virtual void Add(TEntity entity)
        {
            _session.Save(entity);
        }

        public virtual void Remove(TKey id)
        {
            var entityToDelete = _session.Get<TEntity>(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity != null)
            {
                _session.Delete(entity);
            }
        }

        public virtual void Edit(TEntity entityToUpdate)
        {
            _session.Update(entityToUpdate);
            _session.Flush(); // Flush changes to the database
        }

        public virtual TEntity GetById(TKey id)
        {
            return _session.Get<TEntity>(id);
        }

        public virtual IList<TEntity> GetAll()
        {
            return _session.Query<TEntity>().ToList();
        }
    }
}
