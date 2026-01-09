using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;

namespace ThesisHub.Infrastructure.Contracts
{
    public interface IDepartmentRepository
    {
        Task<DepartmentDto> Get(int id);

        Task<List<DepartmentDto>> GetAll(string filter);

        Task<bool> Add(Request<Department> request);

        Task<bool> Update(Request<Department> request);

        Task<bool> Delete(int id);
    }
}