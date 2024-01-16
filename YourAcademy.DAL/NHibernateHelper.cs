using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using YourAcademy.DAL.MappingFiles;

namespace YourAcademy.DAL 
{
    public class NHibernateHelper : INHibernateHelper
    {
        private ISessionFactory _sessionFactory;

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
                 .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                 .BuildSessionFactory();
        }
    }
}

