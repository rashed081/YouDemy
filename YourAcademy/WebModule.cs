using Autofac;

namespace YourAcademy
{
    public class WebModule : Module
    {
        public WebModule()
        { }

        protected override void Load(ContainerBuilder builder)
        {
           
            base.Load(builder);
        }
    }
}
