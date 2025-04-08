using Microsoft.EntityFrameworkCore;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Core;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Core
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected ThesisHubContext Context;

        public BaseRepository(ThesisHubContext context)
        {
            Context = context;
        }

        protected bool EntityExists(int id)
        {
            return Context.Set<T>().Any(e => e.Id == id);
        }

        protected async Task<T> GetEntity(int id)
        {
            var entityDb = await Context.Set<T>().FindAsync(id);
            if (entityDb == null)
            {
                throw new Exception("Not found");
            }

            return entityDb;
        }

        protected async Task<List<T>> GetAllEntities()
        {
            var entitiesDb = await Context.Set<T>().ToListAsync();
            if (!entitiesDb.Any())
            {
                throw new Exception("No data found");
            }

            return entitiesDb;
        }

        protected async Task<Response<T>> AddEntityToDb(T dbEntity)
        {
            Context.Set<T>().Add(dbEntity);
            await Context.SaveChangesAsync();
            return new Response<T> { Success = true, Message = "Added successfully!" };
        }

        public async Task<Response<T>> UpdateEntityInDb(T dbEntity)
        {
            var response = new Response<T>() { Success = true, Message = "Updated successfully!" };

            try
            {
                Context.Update(dbEntity);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                response.Success = false;

                if (!EntityExists(dbEntity.Id))
                {
                    response.Message = "Entity not found!";
                }
                else
                {
                    response.Message = "Concurrency error!";
                }

                throw;
            }

            return response;
        }

        public async Task<Response<T>> DeleteEntityFromDb(T dbEntity)
        {
            Context.Set<T>().Remove(dbEntity);
            await Context.SaveChangesAsync();
            return new Response<T> { Success = true, Message = "deleted successfully!" };
        }
    }
}
