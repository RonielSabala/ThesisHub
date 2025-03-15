using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThesisHub.Domain.Entities;
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

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll(string filter = "")
    {
        var list = await _context.Departments.ToListAsync();

        if (!string.IsNullOrEmpty(filter))
        {
            filter = filter.ToLower();
            list = list.Where(d => d.DeptName.ToLower().Contains(filter)).ToList();
        }

        return Ok(list);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await _context.Departments.FindAsync(id);
        if (entity == null)
        {
            return BadRequest("Not found");
        }

        return Ok(entity);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Create([FromBody] Department entity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The entity is invalid");
        }

        _context.Departments.Add(entity);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Created successfully!" });
    }

    [HttpPut("Edit")]
    public async Task<IActionResult> Edit([FromBody] Department entity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The entity is invalid");
        }

        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DepartmentExists(entity.Id))
            {
                return BadRequest("Not found");
            }
            else
            {
                throw;
            }
        }

        return Ok(new { success = true, message = "Updated successfully!" });
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _context.Departments.FindAsync(id);
        if (entity == null)
        {
            return BadRequest("Not found");
        }

        _context.Departments.Remove(entity);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Deleted successfully!" });
    }

    private bool DepartmentExists(int id)
    {
        return _context.Departments.Any(e => e.Id == id);
    }
}
