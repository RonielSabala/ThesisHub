using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;
using ThesisHub.Infrastructure.Core;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DataContext context) : base(context) { }

        public async Task<Document> GetDocument(Comment dbEntity)
        {
            return await Context.Documents.FindAsync(dbEntity.DocumentId);
        }

        public async Task<Tutor> GetTutor(Comment dbEntity)
        {
            return await Context.Tutors.FindAsync(dbEntity.TutorId);
        }

        public async Task<CommentDto> GetDtoFromEntity(Comment dbEntity)
        {
            var document = dbEntity.Document;
            var tutor = dbEntity.Tutor;

            if (document == null)
            {
                document = await GetDocument(dbEntity);
                dbEntity.Document = document;
            }

            if (tutor == null)
            {
                tutor = await GetTutor(dbEntity);
                dbEntity.Tutor = tutor;
            }

            return new CommentDto
            {
                Id = dbEntity.Id,
                CommentText = dbEntity.CommentText,
                UploadDate = dbEntity.UploadDate,
                DocumentId = document.Id,
                TutorId = tutor.Id,
                DocName = document.DocName,
                TutorName = $"{tutor.FirstName} {tutor.LastName}",
            };
        }

        public async Task<CommentDto> Get(int id)
        {
            var dbEntity = await GetEntity(id);
            return await GetDtoFromEntity(dbEntity);
        }

        public async Task<List<CommentDto>> GetAll(string filter = "")
        {
            var dbEntities = await GetAllEntities();
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                dbEntities = dbEntities.Where(d => d.CommentText.ToLower().Contains(filter)).ToList();
            }

            var entities = new List<CommentDto>();
            foreach (var dbEntity in dbEntities)
            {
                entities.Add(await GetDtoFromEntity(dbEntity));
            }

            return entities;
        }

        public async Task<bool> Add(Request<Comment> request)
        {
            var dbEntity = request.Data;
            dbEntity.Document = await GetDocument(dbEntity);
            dbEntity.Tutor = await GetTutor(dbEntity);
            return await AddEntityToDb(dbEntity);
        }

        public async Task<bool> Update(Request<Comment> request)
        {
            var dbEntity = request.Data;
            dbEntity.Document = await GetDocument(dbEntity);
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
