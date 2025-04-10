using Microsoft.EntityFrameworkCore;
using ThesisHub.Domain.Core;
using ThesisHub.Infrastructure.Contracts;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Core
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext Context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(DataContext context)
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

        public async Task<bool> AddEntityToDb(T dbEntity)
        {
            DbSet.Add(dbEntity);
            return true;
        }

        public async Task<bool> UpdateEntityInDb(T dbEntity)
        {
            DbSet.Update(dbEntity);
            return true;
        }

        public async Task<bool> DeleteEntityFromDb(T dbEntity)
        {
            DbSet.Remove(dbEntity);
            return true;
        }
    }
}
