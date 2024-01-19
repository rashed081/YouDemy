using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using YourAcademy.DAL.MappingFiles;
using NHibernate.Tool.hbm2ddl;

namespace YourAcademy.DAL
{
    public class NHibernateHelper : INHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    InitializeSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Server= DESKTOP-SFPAGI6\\SQL16;Database=YourAcademyDb;User Id=sa;Password=1234;"))
                 .CurrentSessionContext<NHibernate.Context.WebSessionContext>()
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CourseMap>())
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMap>())
                 .Mappings(m=> m.FluentMappings.AddFromAssemblyOf<CartMap>())
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderMap>())
                 //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                 .BuildSessionFactory();
        }
    }
}