using ThesisHub.Common.Responses;
using ThesisHub.Domain.Core;

namespace ThesisHub.Infrastructure.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> EntityExists(int id);

        Task<T> GetEntity(int id);

        Task<List<T>> GetAllEntities();

        Task<Response<T>> AddEntityToDb(T dbEntity);

        Task<Response<T>> UpdateEntityInDb(T dbEntity);

        Task<Response<T>> DeleteEntityFromDb(T dbEntity);
    }
}