using Microsoft.AspNetCore.Mvc;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;

namespace ThesisHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDepartmentRepository _repo;

    public DepartmentsController(IUnitOfWork unitOfWork, IDepartmentRepository repo)
    {
        _unitOfWork = unitOfWork;
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
        var response = new Response<Department> { Success = false };

        if (!ModelState.IsValid)
        {
            response.Message = "The Model is Invalid";
            return response;
        }

        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var request = GetRequestFromDto(dto);
            var repo_response = await _repo.Add(request);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();

            response.Success = true;
            response.Message = repo_response.Message;
        }
        catch (Exception e)
        {
            response.Message = $"Creation error! {e}";
            await _unitOfWork.RollbackTransactionAsync();
        }

        return response;
    }

    [HttpPut(nameof(Update))]
    public async Task<Response<Department>> Update([FromBody] DepartmentDto dto)
    {
        var response = new Response<Department> { Success = false };

        if (!ModelState.IsValid)
        {
            response.Message = "The Model is Invalid";
            return response;
        }

        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var request = GetRequestFromDto(dto);
            var repo_response = await _repo.Update(request);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();

            response.Success = true;
            response.Message = repo_response.Message;
        }
        catch (Exception e)
        {
            response.Message = $"Updating error! {e}";
            await _unitOfWork.RollbackTransactionAsync();
        }

        return response;
    }

    [HttpDelete("Delete/{id}")]
    public async Task<Response<Department>> Delete(int id)
    {
        var response = new Response<Department> { Success = false };

        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var repo_response = await _repo.Delete(id);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();

            response.Success = true;
            response.Message = repo_response.Message;
        }
        catch (Exception e)
        {
            response.Message = $"Deleting error! {e}";
            await _unitOfWork.RollbackTransactionAsync();
        }

        return response;
    }
}
