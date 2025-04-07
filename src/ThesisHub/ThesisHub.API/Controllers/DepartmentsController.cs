using Microsoft.AspNetCore.Mvc;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Repositories;

namespace ThesisHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly DepartmentRepository _repo;

    public DepartmentsController(DepartmentRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("Get/{id}")]
    public async Task<DepartmentDto> Get(int id)
    {
        return await _repo.Get(id);
    }

    [HttpGet(nameof(GetAll))]
    public async Task<List<DepartmentDto>> GetAll(string filter = "")
    {
        return await _repo.GetAll(filter);
    }

    [HttpPost(nameof(Add))]
    public async Task<Response<Department>> Add([FromBody] DepartmentDto request)
    {
        var entity = new Department
        {
            Id = request.Id,
            DeptName = request.DeptName,
            FacultyHead = request.FacultyHead,
            Email = request.Email,
        };

        var new_request = new Request<Department> { Data = entity };
        return await _repo.Add(new_request);
    }

    [HttpPut(nameof(Update))]
    public async Task<Response<Department>> Update([FromBody] DepartmentDto request)
    {
        var entity = new Department
        {
            Id = request.Id,
            DeptName = request.DeptName,
            FacultyHead = request.FacultyHead,
            Email = request.Email,
        };

        var new_request = new Request<Department> { Data = entity };
        return await _repo.Update(new_request);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<Response<Department>> Delete(int id)
    {
        return await _repo.Delete(id);
    }
}
