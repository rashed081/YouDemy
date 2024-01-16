using NHibernate;

namespace YourAcademy.DAL
{
    public interface INHibernateHelper
    {
        public ISessionFactory SessionFactory { get;}
        ISession OpenSession();

        void InitializeSessionFactory();
    }
}
