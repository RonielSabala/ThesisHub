using Microsoft.AspNetCore.Mvc;
using ThesisHub.Web.ViewModels;

namespace ThesisHub.Web.Controllers
{
    public class CommentsController : Controller
    {
        public IActionResult Index()
        {
            return View(new CommentViewModel());
        }

        public IActionResult Create()
        {
            return View(new CommentViewModel());
        }

        public IActionResult Details(int id)
        {
            return View(new CommentViewModel { Id = id });
        }

        public IActionResult Edit(int id)
        {
            return View(new CommentViewModel { Id = id });
        }

        public IActionResult Delete(int id)
        {
            return View(new CommentViewModel { Id = id });
        }
    }
}
