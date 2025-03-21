using Microsoft.AspNetCore.Mvc;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Infrastructure.Interfaces;

namespace ThesisHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _repo;

    public StudentsController(IStudentRepository repo)
    {
        _repo = repo;
    }

    [HttpGet(nameof(GetAll))]
    public async Task<ActionResult<List<StudentDto>>> GetAll(string filter = "")
    {
        return await _repo.GetAll();
    }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<StudentDto>> Get(int id)
    {
        return await _repo.Get(id);
    }

    [HttpPost(nameof(Add))]
    public async Task<ActionResult<AddStudentResponse>> Add([FromBody] AddStudentRequest request)
    {
        return await _repo.Add(request);
    }

    [HttpPut(nameof(Update))]
    public async Task<ActionResult<UpdateStudentResponse>> Update([FromBody] UpdateStudentRequest request)
    {
        return await _repo.Update(request);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult<DeleteStudentResponse>> Delete(int id)
    {
        return await _repo.Delete(id);
    }
}
