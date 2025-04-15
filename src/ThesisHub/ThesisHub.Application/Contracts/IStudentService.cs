using ThesisHub.Common.Dtos;

namespace ThesisHub.Application.Contracts
{
    public interface IStudentService
    {
        Task<StudentDto> Get(int id);

        Task<List<StudentDto>> GetAll(string filter);

        Task<bool> Add(StudentDto dto);

        Task<bool> Update(StudentDto dto);

        Task<bool> Delete(int id);
    }
}