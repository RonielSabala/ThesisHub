using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;

namespace ThesisHub.Infrastructure.Contracts
{
    public interface IProjectRepository
    {
        string GetProjectStatusString(ProjectStatusEnum status);

        ProjectStatusEnum GetProjectStatusEnum(string status);

        Task<ProjectDto> Get(int id);

        Task<List<ProjectDto>> GetAll(string filter = "");

        Task<bool> Add(Request<Project> request);

        Task<bool> Update(Request<Project> request);

        Task<bool> Delete(int id);
    }
}