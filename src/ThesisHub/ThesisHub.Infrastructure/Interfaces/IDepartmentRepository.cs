using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;

namespace ThesisHub.Infrastructure.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentDto>> GetAll(string filter = "");
        Task<DepartmentDto> Get(int id);
        Task<AddDepartmentResponse> Add(AddDepartmentRequest request);
        Task<UpdateDepartmentResponse> Update(UpdateDepartmentRequest request);
        Task<DeleteDepartmentResponse> Delete(int id);
    }
}
