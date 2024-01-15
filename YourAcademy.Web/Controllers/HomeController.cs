using Autofac;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YourAcademy.Models;
using YourAcademy.Web.Models;

namespace YourAcademy.Controllers
{
    public class HomeController : Controller
    {
        ILifetimeScope _scope;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

       
        public IActionResult Index()
        {
            var model = _scope.Resolve<CourseViewModel>();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
