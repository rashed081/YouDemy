using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using YourAcademy.DAL.MappingFiles;

namespace YourAcademy.DAL 
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                InitializeSessionFactory();
            }

            return _sessionFactory.OpenSession();
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString("Data Source=:memory:;Version=3;New=True;"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CourseMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }
    }
}

