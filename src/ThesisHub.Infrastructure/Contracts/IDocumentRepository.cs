using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;

namespace ThesisHub.Infrastructure.Contracts
{
    public interface IDocumentRepository
    {
        Task<DocumentDto> Get(int id);

        Task<List<DocumentDto>> GetAll(string filter);

        Task<bool> Add(Request<Document> request);

        Task<bool> Update(Request<Document> request);

        Task<bool> Delete(int id);
    }
}