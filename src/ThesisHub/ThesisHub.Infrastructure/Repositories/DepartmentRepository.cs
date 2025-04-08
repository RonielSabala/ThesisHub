using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;
using ThesisHub.Infrastructure.Core;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ThesisHubContext context) : base(context) { }

        public async Task<DepartmentDto> Get(int id)
        {
            var dbEntity = await GetEntity(id);
            return new DepartmentDto
            {
                Id = dbEntity.Id,
                DeptName = dbEntity.DeptName,
                FacultyHead = dbEntity.FacultyHead,
                Email = dbEntity.Email,
            };
        }

        public async Task<List<DepartmentDto>> GetAll(string filter = "")
        {
            var dbEntities = await GetAllEntities();

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                dbEntities = dbEntities.Where(d => d.DeptName.ToLower().Contains(filter)).ToList();
            }

            var entities = new List<DepartmentDto>();
            foreach (var dbEntity in dbEntities)
            {
                entities.Add(new DepartmentDto
                {
                    Id = dbEntity.Id,
                    DeptName = dbEntity.DeptName,
                    FacultyHead = dbEntity.FacultyHead,
                    Email = dbEntity.Email,
                });
            }

            return entities;
        }

        public async Task<bool> Add(Request<Department> request)
        {
            var dbEntity = request.Data;
            return await AddEntityToDb(dbEntity);
        }

        public async Task<bool> Update(Request<Department> request)
        {
            var dbEntity = request.Data;
            return await UpdateEntityInDb(dbEntity);
        }

        public async Task<bool> Delete(int id)
        {
            var dbEntity = await GetEntity(id);
            return await DeleteEntityFromDb(dbEntity);
        }
    }
}
