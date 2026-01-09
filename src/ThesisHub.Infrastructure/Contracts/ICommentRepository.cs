using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;

namespace ThesisHub.Infrastructure.Contracts
{
    public interface ICommentRepository
    {
        Task<Document> GetDocument(Comment dbEntity);

        Task<Tutor> GetTutor(Comment dbEntity);

        Task<CommentDto> Get(int id);

        Task<List<CommentDto>> GetAll(string filter);

        Task<bool> Add(Request<Comment> request);

        Task<bool> Update(Request<Comment> request);

        Task<bool> Delete(int id);
    }
}