using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;

namespace ThesisHub.Infrastructure.Contracts
{
    public interface IStudentRepository
    {
        Task<StudentDto> Get(int id);

        Task<List<StudentDto>> GetAll(string filter);

        Task<bool> Add(Request<Student> request);

        Task<bool> Update(Request<Student> request);

        Task<bool> Delete(int id);
    }
}