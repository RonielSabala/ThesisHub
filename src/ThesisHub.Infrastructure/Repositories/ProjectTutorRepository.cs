using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;
using ThesisHub.Infrastructure.Core;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Repositories
{
    public class ProjectTutorRepository : BaseRepository<ProjectTutor>, IProjectTutorRepository
    {
        public ProjectTutorRepository(DataContext context) : base(context) { }

        public async Task<Project> GetProject(ProjectTutor dbEntity)
        {
            return await Context.Projects.FindAsync(dbEntity.ProjectId);
        }

        public async Task<Tutor> GetTutor(ProjectTutor dbEntity)
        {
            return await Context.Tutors.FindAsync(dbEntity.TutorId);
        }

        public async Task<ProjectTutorDto> GetDtoFromEntity(ProjectTutor dbEntity)
        {
            var project = dbEntity.Project;
            var tutor = dbEntity.Tutor;

            if (project == null)
            {
                project = await GetProject(dbEntity);
                dbEntity.Project = project;
            }

            if (tutor == null)
            {
                tutor = await GetTutor(dbEntity);
                dbEntity.Tutor = tutor;
            }

            return new ProjectTutorDto
            {
                Id = dbEntity.Id,
                ProjectId = project.Id,
                TutorId = tutor.Id,
                TutorRole = dbEntity.TutorRole,
                ProjectTitle = project.Title,
                TutorName = $"{tutor.FirstName} {tutor.LastName}",
            };
        }

        public async Task<ProjectTutorDto> Get(int id)
        {
            var dbEntity = await GetEntity(id);
            return await GetDtoFromEntity(dbEntity);
        }

        public async Task<List<ProjectTutorDto>> GetAll(string filter = "", bool filterProject = true)
        {
            var dbEntities = await GetAllEntities();
            var entities = new List<ProjectTutorDto>();
            foreach (var dbEntity in dbEntities)
            {
                entities.Add(await GetDtoFromEntity(dbEntity));
            }

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                entities = entities.Where(d =>
                    (filterProject ? d.ProjectTitle : d.TutorName)
                    .ToLower()
                    .Contains(filter)
                ).ToList();
            }

            return entities;
        }

        public async Task<bool> Add(Request<ProjectTutor> request)
        {
            var dbEntity = request.Data;
            dbEntity.Project = await GetProject(dbEntity);
            dbEntity.Tutor = await GetTutor(dbEntity);
            return await AddEntityToDb(dbEntity);
        }

        public async Task<bool> Update(Request<ProjectTutor> request)
        {
            var dbEntity = request.Data;
            dbEntity.Project = await GetProject(dbEntity);
            dbEntity.Tutor = await GetTutor(dbEntity);
            return await UpdateEntityInDb(dbEntity);
        }

        public async Task<bool> Delete(int id)
        {
            var dbEntity = await GetEntity(id);
            return await DeleteEntityFromDb(dbEntity);
        }
    }
}
