using Microsoft.AspNetCore.Mvc;
using ThesisHub.Web.ViewModels;

namespace ThesisHub.Web.Controllers
{
    public class DocumentsController : Controller
    {
        public IActionResult Index()
        {
            return View(new DocumentViewModel());
        }

        public IActionResult Create()
        {
            return View(new DocumentViewModel());
        }

        public IActionResult Details(int id)
        {
            return View(new DocumentViewModel { Id = id });
        }

        public IActionResult Edit(int id)
        {
            return View(new DocumentViewModel { Id = id });
        }

        public IActionResult Delete(int id)
        {
            return View(new DocumentViewModel { Id = id });
        }
    }
}
