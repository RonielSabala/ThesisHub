using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;
using ThesisHub.Infrastructure.Core;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext context) : base(context) { }

        public string GetProjectStatusString(ProjectStatusEnum status)
        {
            switch (status)
            {
                case ProjectStatusEnum.InProgress:
                    return "in progress";
                case ProjectStatusEnum.Completed:
                    return "completed";
                case ProjectStatusEnum.UnderReview:
                    return "under review";
                case ProjectStatusEnum.Approved:
                    return "approved";
                case ProjectStatusEnum.Rejected:
                    return "rejected";
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, "Unknown project status.");
            }
        }

        public ProjectStatusEnum GetProjectStatusEnum(string status)
        {
            switch (status.ToLowerInvariant())
            {
                case "in progress":
                    return ProjectStatusEnum.InProgress;
                case "completed":
                    return ProjectStatusEnum.Completed;
                case "under review":
                    return ProjectStatusEnum.UnderReview;
                case "approved":
                    return ProjectStatusEnum.Approved;
                case "rejected":
                    return ProjectStatusEnum.Rejected;
                default:
                    throw new ArgumentException("Invalid project status.");
            }
        }

        public async Task<Student> GetStudent(Project dbEntity)
        {
            return await Context.Students.FindAsync(dbEntity.StudentId);
        }

        public async Task<ProjectDto> GetDtoFromEntity(Project dbEntity)
        {
            var student = dbEntity.Student;
            if (student == null)
            {
                student = await GetStudent(dbEntity);
                dbEntity.Student = student;
            }

            return new ProjectDto
            {
                Id = dbEntity.Id,
                Title = dbEntity.Title,
                ProjectDescription = dbEntity.ProjectDescription,
                RegistrationDate = dbEntity.RegistrationDate,
                ProjectStatus = GetProjectStatusString(dbEntity.ProjectStatus),
                StudentId = student.Id,
                StudentName = $"{student.FirstName} {student.LastName}",
            };
        }

        public async Task<ProjectDto> Get(int id)
        {
            var dbEntity = await GetEntity(id);
            return await GetDtoFromEntity(dbEntity);
        }

        public async Task<List<ProjectDto>> GetAll(string filter = "")
        {
            var dbEntities = await GetAllEntities();
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                dbEntities = dbEntities.Where(d => d.Title.ToLower().Contains(filter)).ToList();
            }

            var entities = new List<ProjectDto>();
            foreach (var dbEntity in dbEntities)
            {
                entities.Add(await GetDtoFromEntity(dbEntity));
            }

            return entities;
        }

        public async Task<bool> Add(Request<Project> request)
        {
            var dbEntity = request.Data;
            dbEntity.Student = await GetStudent(dbEntity);
            return await AddEntityToDb(dbEntity);
        }

        public async Task<bool> Update(Request<Project> request)
        {
            var dbEntity = request.Data;
            dbEntity.Student = await GetStudent(dbEntity);
            return await UpdateEntityInDb(dbEntity);
        }

        public async Task<bool> Delete(int id)
        {
            var dbEntity = await GetEntity(id);
            return await DeleteEntityFromDb(dbEntity);
        }
    }
}
