using Microsoft.AspNetCore.Mvc;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
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

    [HttpGet(nameof(GetAll))]
    public async Task<List<DepartmentDto>> GetAll(string filter = "")
    {
        return await _repo.GetAll(filter);
    }

    [HttpGet("Get/{id}")]
    public async Task<DepartmentDto> Get(int id)
    {
        return await _repo.Get(id);
    }

    [HttpPost(nameof(Add))]
    public async Task<AddDepartmentResponse> Add([FromBody] AddDepartmentRequest request)
    {
        return await _repo.Add(request);
    }

    [HttpPut(nameof(Update))]
    public async Task<UpdateDepartmentResponse> Update([FromBody] UpdateDepartmentRequest request)
    {
        return await _repo.Update(request);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<DeleteDepartmentResponse> Delete(int id)
    {
        return await _repo.Delete(id);
    }
}
