using Microsoft.AspNetCore.Mvc;
using ThesisHub.Application.Services;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;

namespace ThesisHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentService _service;

    public StudentsController(StudentService service)
    {
        _service = service;
    }

    [HttpGet("Get/{id}")]
    public async Task<StudentDto> Get(int id)
    {
        return await _service.Get(id);
    }

    [HttpGet(nameof(GetAll))]
    public async Task<List<StudentDto>> GetAll(string filter = "")
    {
        return await _service.GetAll(filter);
    }

    [HttpPost(nameof(Add))]
    public async Task<Response<Student>> Add([FromBody] StudentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return new Response<Student> { Success = false, Message = "The Model is Invalid" };
        }

        return await _service.Add(dto);
    }

    [HttpPut(nameof(Update))]
    public async Task<Response<Student>> Update([FromBody] StudentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return new Response<Student> { Success = false, Message = "The Model is Invalid" };
        }

        return await _service.Update(dto);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<Response<Student>> Delete(int id)
    {
        return await _service.Delete(id);
    }
}
