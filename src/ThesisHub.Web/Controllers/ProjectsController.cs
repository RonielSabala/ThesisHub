using Microsoft.AspNetCore.Mvc;
using ThesisHub.Web.ViewModels;

namespace ThesisHub.Web.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View(new ProjectViewModel());
        }

        public IActionResult Create()
        {
            return View(new ProjectViewModel());
        }

        public IActionResult Details(int id)
        {
            return View(new ProjectViewModel { Id = id });
        }

        public IActionResult Edit(int id)
        {
            return View(new ProjectViewModel { Id = id });
        }

        public IActionResult Delete(int id)
        {
            return View(new ProjectViewModel { Id = id });
        }
    }
}
