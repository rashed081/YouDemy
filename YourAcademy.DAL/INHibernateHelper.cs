using NHibernate;

namespace YourAcademy.DAL
{
    public interface INHibernateHelper
    {
        ISessionFactory SessionFactory { get; }

        ISession OpenSession();
    }
}
