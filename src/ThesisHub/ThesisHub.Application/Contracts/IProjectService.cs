using ThesisHub.Common.Dtos;

namespace ThesisHub.Application.Contracts
{
    public interface IProjectService
    {
        Task<ProjectDto> Get(int id);

        Task<List<ProjectDto>> GetAll(string filter);

        Task<bool> Add(ProjectDto dto);

        Task<bool> Update(ProjectDto dto);

        Task<bool> Delete(int id);
    }
}