using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;

namespace ThesisHub.Infrastructure.Contracts
{
    public interface IProjectTutorRepository
    {
        Task<Project> GetProject(ProjectTutor dbEntity);

        Task<Tutor> GetTutor(ProjectTutor dbEntity);

        Task<ProjectTutorDto> Get(int id);

        Task<List<ProjectTutorDto>> GetAll(string filter, bool filterProject);

        Task<bool> Add(Request<ProjectTutor> request);

        Task<bool> Update(Request<ProjectTutor> request);

        Task<bool> Delete(int id);
    }
}