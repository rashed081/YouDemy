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
            model.LoadCourses();
            return View(model);
        }
        public IActionResult Create()
        {
            var model = _scope.Resolve<CourseCreateModel>();
            model.LoadCategories();
            return View(model);
        }

        
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CourseCreateModel model)
        {
            model.ResolveDependency(_scope);
            model.LoadCategories();
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateCourse();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
                }
            }

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
