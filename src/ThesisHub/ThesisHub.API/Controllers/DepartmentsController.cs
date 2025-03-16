using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThesisHub.Domain.Entities;
using ThesisHub.Persistence;
using ThesisHub.Presentation.Dtos;

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

    [HttpGet(nameof(GetAll))]
    public async Task<IActionResult> GetAll(string filter = "")
    {
        var entities = await _context.Departments.ToListAsync();

        if (!string.IsNullOrEmpty(filter))
        {
            filter = filter.ToLower();
            entities = entities.Where(d => d.DeptName.ToLower().Contains(filter)).ToList();
        }
        
        var list = entities.Select(entity => new DepartmentDto
        {
            Id = entity.Id,
            DeptName = entity.DeptName,
            FacultyHead = entity.FacultyHead,
            Email = entity.Email
        }).ToList();

        return Ok(list);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var entitydb = await _context.Departments.FindAsync(id);
        if (entitydb == null)
        {
            return BadRequest("Not found");
        }

        var entity = new DepartmentDto
        {
            Id = entitydb.Id,
            DeptName = entitydb.DeptName,
            FacultyHead = entitydb.FacultyHead,
            Email = entitydb.Email,
        };

        return Ok(entity);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Create([FromBody] DepartmentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The entity is invalid");
        }

        var entity = new Department { 
            Id=dto.Id,
            DeptName=dto.DeptName,
            FacultyHead=dto.FacultyHead,
            Email=dto.Email,
        };

        _context.Departments.Add(entity);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Created successfully!" });
    }

    [HttpPut(nameof(Update))]
    public async Task<IActionResult> Update([FromBody] DepartmentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The entity is invalid");
        }

        var entity = new Department
        {
            Id = dto.Id,
            DeptName = dto.DeptName,
            FacultyHead = dto.FacultyHead,
            Email = dto.Email,
        };

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
        var entityDb = await _context.Departments.FindAsync(id);
        if (entityDb == null)
        {
            return BadRequest("Not found");
        }

        _context.Departments.Remove(entityDb);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Deleted successfully!" });
    }

    private bool DepartmentExists(int id)
    {
        return _context.Departments.Any(e => e.Id == id);
    }
}
