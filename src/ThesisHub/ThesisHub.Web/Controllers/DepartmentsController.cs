using Microsoft.AspNetCore.Mvc;
using ThesisHub.Domain.Entities;
using ThesisHub.Persistence;

namespace ThesisHub.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ThesisHubContext _context;

        public DepartmentsController(ThesisHubContext context)
        {
            _context = context;
        }

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
            return View(new Department { Id = id });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(new Department { Id = id});
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(new Department { Id = id });
        }
    }
}
