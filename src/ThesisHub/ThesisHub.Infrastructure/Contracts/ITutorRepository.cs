using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;

namespace ThesisHub.Infrastructure.Contracts
{
    public interface ITutorRepository
    {
        Task<TutorDto> Get(int id);

        Task<List<TutorDto>> GetAll(string filter = "");

        Task<bool> Add(Request<Tutor> request);

        Task<bool> Update(Request<Tutor> request);

        Task<bool> Delete(int id);
    }
}