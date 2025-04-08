using Microsoft.AspNetCore.Mvc;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;

namespace ThesisHub.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStudentRepository _repo;

    public StudentsController(IUnitOfWork unitOfWork, IStudentRepository repo)
    {
        _unitOfWork = unitOfWork;
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
        var response = new Response<Student> { Success = false };

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
    public async Task<Response<Student>> Update([FromBody] StudentDto dto)
    {
        var response = new Response<Student> { Success = false };

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
    public async Task<Response<Student>> Delete(int id)
    {
        var response = new Response<Student> { Success = false };

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
