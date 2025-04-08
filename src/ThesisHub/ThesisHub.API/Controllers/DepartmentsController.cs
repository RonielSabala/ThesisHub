using Microsoft.AspNetCore.Mvc;
using ThesisHub.Application.Services;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;

namespace ThesisHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly DepartmentService _service;

    public DepartmentsController(DepartmentService service)
    {
        _service = service;
    }

    [HttpGet("Get/{id}")]
    public async Task<DepartmentDto> Get(int id)
    {
        return await _service.Get(id);
    }

    [HttpGet(nameof(GetAll))]
    public async Task<List<DepartmentDto>> GetAll(string filter = "")
    {
        return await _service.GetAll(filter);
    }

    [HttpPost(nameof(Add))]
    public async Task<Response<Department>> Add([FromBody] DepartmentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return new Response<Department> { Success = false, Message = "The Model is Invalid" };
        }

        return await _service.Add(dto);
    }

    [HttpPut(nameof(Update))]
    public async Task<Response<Department>> Update([FromBody] DepartmentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return new Response<Department> { Success = false, Message = "The Model is Invalid" };
        }

        return await _service.Update(dto);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<Response<Department>> Delete(int id)
    {
        return await _service.Delete(id);
    }
}
