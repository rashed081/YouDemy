using NHibernate;
using YourAcademy.DAL.Entity;
using YourAcademy.DAL.RepositoryInterface;

namespace YourAcademy.DAL.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable
    {
        private readonly ISession _session;

        public Repository(INHibernateHelper nHibernateHelper)
        {
            _session = nHibernateHelper.OpenSession();
        }

        public virtual void Add(TEntity entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(entity);
                transaction.Commit();
            }
        }

        public virtual TEntity GetById(TKey id)
        {
            return _session.Get<TEntity>(id);
        }

        public virtual IList<TEntity> GetAll()
        {
            return _session.Query<TEntity>().ToList();
        }

        public virtual void Edit(TEntity entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(entity);
                transaction.Commit();
            }
        }

        public virtual void Remove(TKey id)
        {
            var entityToDelete = GetById(id);
            if (entityToDelete != null)
            {
                Remove(entityToDelete);
            }
        }

        public virtual void Remove(TEntity entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(entity);
                transaction.Commit();
            }
        }
    }
}