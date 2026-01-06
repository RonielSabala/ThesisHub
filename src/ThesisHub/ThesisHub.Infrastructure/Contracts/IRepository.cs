using ThesisHub.Domain.Core;

namespace ThesisHub.Infrastructure.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> EntityExists(int id);

        Task<T> GetEntity(int id);

        Task<List<T>> GetAllEntities();

        Task<bool> AddEntityToDb(T dbEntity);

        Task<bool> UpdateEntityInDb(T dbEntity);

        Task<bool> DeleteEntityFromDb(T dbEntity);
    }
}