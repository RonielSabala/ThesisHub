using ThesisHub.Common.Dtos;

namespace ThesisHub.Application.Contracts
{
    public interface IProjectTutorService
    {
        Task<ProjectTutorDto> Get(int id);

        Task<List<ProjectTutorDto>> GetAll(string filter, bool filterProject);

        Task<bool> Add(ProjectTutorDto dto);

        Task<bool> Update(ProjectTutorDto dto);

        Task<bool> Delete(int id);
    }
}