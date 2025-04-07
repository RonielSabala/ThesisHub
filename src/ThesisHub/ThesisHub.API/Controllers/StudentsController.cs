using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Repositories;

namespace ThesisHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentRepository _repo;

    public StudentsController(StudentRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("Get/{id}")]
    public async Task<StudentDto> Get(int id)
    {
        return await _repo.Get(id);
    }

    [HttpGet(nameof(GetAll))]
    public async Task<List<StudentDto>> GetAll(string filter = "")
    {
        return await _repo.GetAll(filter);
    }

    [HttpPost(nameof(Add))]
    public async Task<Response<Student>> Add([FromBody] StudentDto request)
    {
        var entity = new Student
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            DepartmentId = request.DepartmentId
        };

        var new_request = new Request<Student> { Data = entity };
        return await _repo.Add(new_request);
    }

    [HttpPut(nameof(Update))]
    public async Task<Response<Student>> Update([FromBody] Student request)
    {
        var entity = new Student
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            DepartmentId = request.DepartmentId
        };

        var new_request = new Request<Student> { Data = entity };
        return await _repo.Update(new_request);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<Response<Student>> Delete(int id)
    {
        return await _repo.Delete(id);
    }
}
