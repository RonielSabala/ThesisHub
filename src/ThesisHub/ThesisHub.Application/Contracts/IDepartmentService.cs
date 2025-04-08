using ThesisHub.Common.Dtos;

namespace ThesisHub.Application.Contracts
{
    public interface IDepartmentService
    {
        Task<DepartmentDto> Get(int id);
        Task<List<DepartmentDto>> GetAll(string filter = "");
        Task<bool> Add(DepartmentDto dto);
        Task<bool> Update(DepartmentDto dto);
        Task<bool> Delete(int id);
    }
}