using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var entity = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _context.Departments.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
    }
}
