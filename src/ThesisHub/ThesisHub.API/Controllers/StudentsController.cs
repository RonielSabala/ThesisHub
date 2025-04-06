using Microsoft.AspNetCore.Mvc;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
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

    [HttpGet(nameof(GetAll))]
    public async Task<List<StudentDto>> GetAll(string filter = "")
    {
        return await _repo.GetAll(filter);
    }

    [HttpGet("Get/{id}")]
    public async Task<StudentDto> Get(int id)
    {
        return await _repo.Get(id);
    }

    [HttpPost(nameof(Add))]
    public async Task<AddStudentResponse> Add([FromBody] AddStudentRequest request)
    {
        return await _repo.Add(request);
    }

    [HttpPut(nameof(Update))]
    public async Task<UpdateStudentResponse> Update([FromBody] UpdateStudentRequest request)
    {
        return await _repo.Update(request);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<DeleteStudentResponse> Delete(int id)
    {
        return await _repo.Delete(id);
    }
}
