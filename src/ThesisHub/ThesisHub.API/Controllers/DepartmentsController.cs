using Microsoft.AspNetCore.Mvc;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Infrastructure.Interfaces;

namespace ThesisHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentRepository _repo;

    public DepartmentsController(IDepartmentRepository repo)
    {
        _repo = repo;
    }

    [HttpGet(nameof(GetAll))]
    public async Task<ActionResult<List<DepartmentDto>>> GetAll(string filter = "")
    {
        return await _repo.GetAll();
    }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<DepartmentDto>> Get(int id)
    {
        return await _repo.Get(id);
    }

    [HttpPost(nameof(Add))]
    public async Task<ActionResult<AddDepartmentResponse>> Add([FromBody] AddDepartmentRequest request)
    {
        return await _repo.Add(request);
    }

    [HttpPut(nameof(Update))]
    public async Task<ActionResult<UpdateDepartmentResponse>> Update([FromBody] UpdateDepartmentRequest request)
    {
        return await _repo.Update(request);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult<DeleteDepartmentResponse>> Delete(int id)
    {
        return await _repo.Delete(id);
    }
}
