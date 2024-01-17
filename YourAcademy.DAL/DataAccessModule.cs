using Autofac;
using YourAcademy.DAL.Repositories;
using YourAcademy.DAL.RepositoryInterface;
using YourAcademy.DAL.UnitOfWork;

namespace YourAcademy.DAL
{
    public class DataAccessModule:Module
    {
        public DataAccessModule()
        { }


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<NHibernateHelper>().As<INHibernateHelper>().SingleInstance();
            
            //builder.RegisterType<NHibernateMiddleware>();

            base.Load(builder);
        }

    }
}
