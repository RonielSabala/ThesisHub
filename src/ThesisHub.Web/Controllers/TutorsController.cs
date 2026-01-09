using Microsoft.AspNetCore.Mvc;
using ThesisHub.Web.ViewModels;

namespace ThesisHub.Web.Controllers
{
    public class TutorsController : Controller
    {
        public IActionResult Index()
        {
            return View(new TutorViewModel());
        }

        public IActionResult Create()
        {
            return View(new TutorViewModel());
        }

        public IActionResult Details(int id)
        {
            return View(new TutorViewModel { Id = id });
        }

        public IActionResult Edit(int id)
        {
            return View(new TutorViewModel { Id = id });
        }

        public IActionResult Delete(int id)
        {
            return View(new TutorViewModel { Id = id });
        }
    }
}
