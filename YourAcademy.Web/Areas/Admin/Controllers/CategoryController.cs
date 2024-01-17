using Autofac;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using YourAcademy.Controllers;
using YourAcademy.Web.Areas.Admin.Models;

namespace YourAcademy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        ILifetimeScope _scope;
        private readonly ILogger<HomeController> _logger;

        public CategoryController(ILogger<HomeController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }


        public IActionResult Index()
        {
            var model = _scope.Resolve<CategoryModel>();
            model.LoadCategories();
            return View(model);
        }
        public IActionResult Create()
        {
            var model = _scope.Resolve<CategoryModel>();
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel model)
        {
            model.ResolveDependency(_scope);

            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateCatagory();
                    return RedirectToAction("Index");
                }
                catch (DuplicateNameException ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Server Error");
                }
            }

            return View(model);
        }
    }
}
