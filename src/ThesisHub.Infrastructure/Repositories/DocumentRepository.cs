using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;
using ThesisHub.Infrastructure.Core;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Repositories
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(DataContext context) : base(context) { }

        public async Task<Project> GetProject(Document dbEntity)
        {
            return await Context.Projects.FindAsync(dbEntity.ProjectId);
        }

        public async Task<DocumentDto> GetDtoFromEntity(Document dbEntity)
        {
            var project = dbEntity.Project;
            if (project == null)
            {
                project = await GetProject(dbEntity);
                dbEntity.Project = project;
            }

            return new DocumentDto
            {
                Id = dbEntity.Id,
                DocName = dbEntity.DocName,
                FilePath = dbEntity.FilePath,
                UploadDate = dbEntity.UploadDate,
                DocStatus = dbEntity.DocStatus,
                ProjectId = project.Id,
                ProjectTitle = project.Title,
            };
        }

        public async Task<DocumentDto> Get(int id)
        {
            var dbEntity = await GetEntity(id);
            return await GetDtoFromEntity(dbEntity);
        }

        public async Task<List<DocumentDto>> GetAll(string filter = "")
        {
            var dbEntities = await GetAllEntities();
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                dbEntities = dbEntities.Where(d => d.DocName.ToLower().Contains(filter)).ToList();
            }

            var entities = new List<DocumentDto>();
            foreach (var dbEntity in dbEntities)
            {
                entities.Add(await GetDtoFromEntity(dbEntity));
            }

            return entities;
        }

        public async Task<bool> Add(Request<Document> request)
        {
            var dbEntity = request.Data;
            dbEntity.Project = await GetProject(dbEntity);
            return await AddEntityToDb(dbEntity);
        }

        public async Task<bool> Update(Request<Document> request)
        {
            var dbEntity = request.Data;
            dbEntity.Project = await GetProject(dbEntity);
            return await UpdateEntityInDb(dbEntity);
        }

        public async Task<bool> Delete(int id)
        {
            var dbEntity = await GetEntity(id);
            return await DeleteEntityFromDb(dbEntity);
        }
    }
}
