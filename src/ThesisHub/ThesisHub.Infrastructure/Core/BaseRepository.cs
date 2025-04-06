using Microsoft.EntityFrameworkCore;
using ThesisHub.Common.core;
using ThesisHub.Domain.Core;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Core
{
    public class BaseRepository<Entity, AddResponse, UpdateResponse, DeleteResponse>
        where Entity : BaseEntity
        where AddResponse : BaseResponse, new()
        where UpdateResponse : BaseResponse, new()
        where DeleteResponse : BaseResponse, new()
    {
        protected ThesisHubContext Context;

        public BaseRepository(ThesisHubContext context)
        {
            Context = context;
        }

        protected bool EntityExists(int id)
        {
            return Context.Set<Entity>().Any(e => e.Id == id);
        }

        protected async Task<Entity> GetEntity(int id)
        {
            var entityDb = await Context.Set<Entity>().FindAsync(id);
            if (entityDb == null)
            {
                throw new Exception("Not found");
            }

            return entityDb;
        }

        protected async Task<List<Entity>> GetAllEntities()
        {
            var entitiesDb = await Context.Set<Entity>().ToListAsync();
            if (!entitiesDb.Any())
            {
                throw new Exception("No data found");
            }

            return entitiesDb;
        }

        protected async Task<AddResponse> AddEntityToDb(Entity dbEntity)
        {
            Context.Set<Entity>().Add(dbEntity);
            await Context.SaveChangesAsync();
            return new AddResponse();
        }

        public async Task<UpdateResponse> UpdateEntityInDb(Entity dbEntity)
        {
            try
            {
                Context.Update(dbEntity);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(dbEntity.Id))
                {
                    throw new Exception("Not found");
                }
                else
                {
                    throw;
                }
            }

            return new UpdateResponse();
        }

        public async Task<DeleteResponse> DeleteEntityFromDb(Entity dbEntity)
        {
            Context.Set<Entity>().Remove(dbEntity);
            await Context.SaveChangesAsync();
            return new DeleteResponse();
        }
    }
}
