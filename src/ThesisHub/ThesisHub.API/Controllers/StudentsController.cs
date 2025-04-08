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

    private static Request<Student> GetRequestFromDto(StudentDto request)
    {
        var dbEntity = new Student
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            DepartmentId = request.DepartmentId
        };

        return new Request<Student> { Data = dbEntity };
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
    public async Task<Response<Student>> Add([FromBody] StudentDto dto)
    {
        var request = GetRequestFromDto(dto);
        return await _repo.Add(request);
    }

    [HttpPut(nameof(Update))]
    public async Task<Response<Student>> Update([FromBody] StudentDto dto)
    {
        var request = GetRequestFromDto(dto);
        return await _repo.Update(request);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<Response<Student>> Delete(int id)
    {
        return await _repo.Delete(id);
    }
}
