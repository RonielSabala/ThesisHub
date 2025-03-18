using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThesisHub.Domain.Entities;
using ThesisHub.Persistence;
using ThesisHub.Presentation.Dtos;

namespace ThesisHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ThesisHubContext _context;

    public StudentsController(ThesisHubContext context)
    {
        _context = context;
    }

    [HttpGet(nameof(GetAll))]
    public async Task<IActionResult> GetAll(string filter = "")
    {
        var entities = await _context.Students.ToListAsync();

        if (!string.IsNullOrEmpty(filter))
        {
            filter = filter.ToLower();
            entities = entities.Where(d => d.FirstName.ToLower().Contains(filter)).ToList();
        }

        var list = entities.Select(entity => new StudentDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone,
            DepartmentId = entity.DepartmentId,
        }).ToList();

        return Ok(list);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var entitydb = await _context.Students.FindAsync(id);
        if (entitydb == null)
        {
            return BadRequest("Not found");
        }

        var entity = new StudentDto
        {
            Id = entitydb.Id,
            FirstName = entitydb.FirstName,
            LastName = entitydb.LastName,
            Email = entitydb.Email,
            Phone = entitydb.Phone,
            DepartmentId = entitydb.DepartmentId,
        };

        return Ok(entity);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Create([FromBody] StudentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The entity is invalid");
        }

        var entity = new Student
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            DepartmentId = dto.DepartmentId,
        };

        _context.Students.Add(entity);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Created successfully!" });
    }

    [HttpPut(nameof(Update))]
    public async Task<IActionResult> Update([FromBody] StudentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("The entity is invalid");
        }

        var entity = new Student
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            DepartmentId = dto.DepartmentId,
        };

        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(entity.Id))
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
        var entityDb = await _context.Students.FindAsync(id);
        if (entityDb == null)
        {
            return BadRequest("Not found");
        }

        _context.Students.Remove(entityDb);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Deleted successfully!" });
    }

    private bool StudentExists(int id)
    {
        return _context.Students.Any(e => e.Id == id);
    }
}
