using Autofac;
using YourAcademy.Services.Interface;
using YourAcademy.Services.Services;

namespace YourAcademy.Service
{
    public class ServiceModule : Module
    {
        public ServiceModule()
        { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseService>().As<ICourseService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
