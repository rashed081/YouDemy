using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net;
using log4net.Config;
using NHibernate;
using NHibernate.AspNet.Identity;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;
using YourAcademy.Entity;

namespace YourAcademy.DataAccessLayer
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static NHibernate.ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                InitializeSessionFactory();
            }

            return _sessionFactory.OpenSession();
        }

        private static void InitializeSessionFactory()
        {
            var log4netConfig = new FileInfo("log4net.config");
            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()), log4netConfig);

            var connectionString = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("DefaultConnection");

            _sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Course>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IdentityUserMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IdentityRoleMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }
    }

}
