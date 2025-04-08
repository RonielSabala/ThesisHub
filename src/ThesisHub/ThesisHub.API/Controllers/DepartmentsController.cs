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

    private static Request<Department> GetRequestFromDto(DepartmentDto request)
    {
        var dbEntity = new Department
        {
            Id = request.Id,
            DeptName = request.DeptName,
            FacultyHead = request.FacultyHead,
            Email = request.Email,
        };

        return new Request<Department> { Data = dbEntity };
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
    public async Task<Response<Department>> Add([FromBody] DepartmentDto dto)
    {
        var request = GetRequestFromDto(dto);
        return await _repo.Add(request);
    }

    [HttpPut(nameof(Update))]
    public async Task<Response<Department>> Update([FromBody] DepartmentDto dto)
    {
        var request = GetRequestFromDto(dto);
        return await _repo.Update(request);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<Response<Department>> Delete(int id)
    {
        return await _repo.Delete(id);
    }
}
