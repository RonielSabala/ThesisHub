using ThesisHub.Common.Dtos;

namespace ThesisHub.Application.Contracts
{
    public interface ICommentService
    {
        Task<CommentDto> Get(int id);

        Task<List<CommentDto>> GetAll(string filter);

        Task<bool> Add(CommentDto dto);

        Task<bool> Update(CommentDto dto);

        Task<bool> Delete(int id);
    }
}