using Microsoft.AspNetCore.Mvc;
using ThesisHub.Web.ViewModels;

namespace ThesisHub.Web.Controllers
{
    public class ProjectTutorsController : Controller
    {
        public IActionResult Index()
        {
            return View(new ProjectTutorViewModel());
        }

        public IActionResult Create()
        {
            return View(new ProjectTutorViewModel());
        }

        public IActionResult Details(int id)
        {
            return View(new ProjectTutorViewModel { Id = id });
        }

        public IActionResult Edit(int id)
        {
            return View(new ProjectTutorViewModel { Id = id });
        }

        public IActionResult Delete(int id)
        {
            return View(new ProjectTutorViewModel { Id = id });
        }
    }
}
