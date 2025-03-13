using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThesisHub.API.Dtos;
using ThesisHub.Persistence;

namespace ThesisHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly ThesisHubContext _context;

    public DepartmentsController(ThesisHubContext context)
    {
        _context = context;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get(string filter = "")
    {
        var list = await _context.Departments.ToListAsync();

        if (!string.IsNullOrEmpty(filter))
        {
            filter = filter.ToLower();
            list = list.Where(d => d.DeptName.ToLower().Contains(filter)).ToList();
        }

        var response = new List<DepartmentDto>();
        foreach (var item in list)
        {
            response.Add(new DepartmentDto
            {
                Id = item.Id,
                DeptName = item.DeptName,
                FacultyHead = item.FacultyHead,
                Email = item.FacultyHead
            });
        }

        return Ok(response);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Create([FromBody] DepartmentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Not found");
        }

        var entityDb = new DepartmentDto
        {
            Id = dto.Id,
            DeptName = dto.DeptName,
            FacultyHead = dto.FacultyHead,
            Email = dto.FacultyHead
        };

        _context.Add(entityDb);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Created successfully!" });
    }
}
