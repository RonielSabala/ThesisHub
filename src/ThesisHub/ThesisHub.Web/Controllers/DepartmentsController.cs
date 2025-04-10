using Microsoft.AspNetCore.Mvc;
using ThesisHub.Web.ViewModels;

namespace ThesisHub.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new DepartmentViewModel());
        }

        public IActionResult Details(int id)
        {
            return View(new DepartmentViewModel { Id = id });
        }

        public IActionResult Edit(int id)
        {
            return View(new DepartmentViewModel { Id = id });
        }

        public IActionResult Delete(int id)
        {
            return View(new DepartmentViewModel { Id = id });
        }
    }
}
