using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;

namespace ThesisHub.Infrastructure.Contracts
{
    public interface IStudentRepository
    {
        Task<Response<Student>> Add(Request<Student> request);
        Task<Response<Student>> Delete(int id);
        Task<StudentDto> Get(int id);
        Task<List<StudentDto>> GetAll(string filter = "");
        Task<Response<Student>> Update(Request<Student> request);
    }
}