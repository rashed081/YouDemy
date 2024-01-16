using Autofac;
using YourAcademy.Web.Models;

namespace YourAcademy
{
    public class WebModule : Module
    {
        public WebModule()
        { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseViewModel>().AsSelf();
            builder.RegisterType<CourseCreateModel>().AsSelf();

            base.Load(builder);
        }
    }
}
