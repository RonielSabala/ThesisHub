using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;

namespace ThesisHub.Infrastructure.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<StudentDto>> GetAll(string filter = "");
        Task<StudentDto> Get(int id);
        Task<AddStudentResponse> Add(AddStudentRequest request);
        Task<UpdateStudentResponse> Update(UpdateStudentRequest request);
        Task<DeleteStudentResponse> Delete(int id);
    }
}
