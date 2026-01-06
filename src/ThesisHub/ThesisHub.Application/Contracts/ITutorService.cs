using ThesisHub.Common.Dtos;

namespace ThesisHub.Application.Contracts
{
    public interface ITutorService
    {
        Task<TutorDto> Get(int id);

        Task<List<TutorDto>> GetAll(string filter);

        Task<bool> Add(TutorDto dto);

        Task<bool> Update(TutorDto dto);

        Task<bool> Delete(int id);
    }
}