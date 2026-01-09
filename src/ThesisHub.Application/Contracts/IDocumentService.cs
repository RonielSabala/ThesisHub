using ThesisHub.Common.Dtos;

namespace ThesisHub.Application.Contracts
{
    public interface IDocumentService
    {
        Task<DocumentDto> Get(int id);

        Task<List<DocumentDto>> GetAll(string filter);

        Task<bool> Add(DocumentDto dto);

        Task<bool> Update(DocumentDto dto);

        Task<bool> Delete(int id);
    }
}