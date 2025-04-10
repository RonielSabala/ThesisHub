using Microsoft.AspNetCore.Mvc;
using ThesisHub.Web.ViewModels;

namespace ThesisHub.Web.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new StudentViewModel());
        }

        public IActionResult Details(int id)
        {
            return View(new StudentViewModel { Id = id });
        }

        public IActionResult Edit(int id)
        {
            return View(new StudentViewModel { Id = id });
        }

        public IActionResult Delete(int id)
        {
            return View(new StudentViewModel { Id = id });
        }
    }
}
