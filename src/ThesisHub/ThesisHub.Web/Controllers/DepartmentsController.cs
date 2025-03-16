using Microsoft.AspNetCore.Mvc;
using ThesisHub.Web.Models;

namespace ThesisHub.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(new DepartmentViewModel { Id = id });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(new DepartmentViewModel { Id = id});
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(new DepartmentViewModel { Id = id });
        }
    }
}
