using Autofac;
using Autofac.Extensions.DependencyInjection;
using log4net;
using NHibernate;
using YourAcademy;
using YourAcademy.DAL;
using YourAcademy.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Log4net 
builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();


var log = LogManager.GetLogger(typeof(Program));

try
{
    builder.Services.AddSingleton(provider =>
    {
        var nhHelper = provider.GetRequiredService<INHibernateHelper>();
        return nhHelper.SessionFactory;
    });

    builder.Services.AddScoped(provider =>
    {
        var sessionFactory = provider.GetRequiredService<ISessionFactory>();
        return sessionFactory.OpenSession();
    });
    //Autofac Configured
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new WebModule());
        containerBuilder.RegisterModule(new DataAccessModule());
        containerBuilder.RegisterModule(new ServiceModule());
    });
    var app = builder.Build();
    
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    //app.UseMiddleware<NHibernateMiddleware>();
    app.UseAuthorization();

    app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    log.Info("Application is starting");
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    app.Run();

}
catch (Exception ex)
{
    log.Fatal($"Application can not start.\n{ex}");
}