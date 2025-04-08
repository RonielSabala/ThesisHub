using Microsoft.EntityFrameworkCore;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Core;
using ThesisHub.Infrastructure.Contracts;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Core
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ThesisHubContext Context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(ThesisHubContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task<bool> EntityExists(int id)
        {
            return await DbSet.AnyAsync(e => e.Id == id);
        }

        public async Task<T> GetEntity(int id)
        {
            var entityDb = await DbSet.FindAsync(id);
            if (entityDb == null)
            {
                throw new Exception("Not found");
            }

            return entityDb;
        }

        public async Task<List<T>> GetAllEntities()
        {
            var entitiesDb = await DbSet.ToListAsync();
            if (!entitiesDb.Any())
            {
                throw new Exception("No data found");
            }

            return entitiesDb;
        }

        public async Task<Response<T>> AddEntityToDb(T dbEntity)
        {
            DbSet.Add(dbEntity);
            return new Response<T> { Success = true, Message = "Added successfully!" };
        }

        public async Task<Response<T>> UpdateEntityInDb(T dbEntity)
        {
            DbSet.Update(dbEntity);
            return new Response<T> { Success = true, Message = "Updated successfully!" };
        }

        public async Task<Response<T>> DeleteEntityFromDb(T dbEntity)
        {
            DbSet.Remove(dbEntity);
            return new Response<T> { Success = true, Message = "deleted successfully!" };
        }
    }
}
