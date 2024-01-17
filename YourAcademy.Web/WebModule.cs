using Autofac;
using YourAcademy.Web.Areas.Admin.Models;
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
            builder.RegisterType<CategoryModel>().AsSelf();


            base.Load(builder);
        }
    }
}
