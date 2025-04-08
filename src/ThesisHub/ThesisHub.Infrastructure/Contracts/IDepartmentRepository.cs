using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;

namespace ThesisHub.Infrastructure.Contracts
{
    public interface IDepartmentRepository
    {
        Task<Response<Department>> Add(Request<Department> request);
        Task<Response<Department>> Delete(int id);
        Task<DepartmentDto> Get(int id);
        Task<List<DepartmentDto>> GetAll(string filter = "");
        Task<Response<Department>> Update(Request<Department> request);
    }
}