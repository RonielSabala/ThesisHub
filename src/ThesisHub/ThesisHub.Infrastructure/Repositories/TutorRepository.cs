using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;
using ThesisHub.Infrastructure.Core;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Repositories
{
    public class TutorRepository : BaseRepository<Tutor>, ITutorRepository
    {
        public TutorRepository(DataContext context) : base(context) { }

        public async Task<Department> GetDepartment(Tutor dbEntity)
        {
            return await Context.Departments.FindAsync(dbEntity.DepartmentId);
        }

        public async Task<TutorDto> GetDtoFromEntity(Tutor dbEntity)
        {
            var department = dbEntity.Department;
            if (department == null)
            {
                department = await GetDepartment(dbEntity);
                dbEntity.Department = department;
            }

            return new TutorDto
            {
                Id = dbEntity.Id,
                FirstName = dbEntity.FirstName,
                LastName = dbEntity.LastName,
                Email = dbEntity.Email,
                Specialization = dbEntity.Specialization,
                DepartmentId = department.Id,
                DeptName = department.DeptName,
            };
        }

        public async Task<TutorDto> Get(int id)
        {
            var dbEntity = await GetEntity(id);
            return await GetDtoFromEntity(dbEntity);
        }

        public async Task<List<TutorDto>> GetAll(string filter = "")
        {
            var dbEntities = await GetAllEntities();
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                dbEntities = dbEntities.Where(d => d.FirstName.ToLower().Contains(filter)).ToList();
            }

            var entities = new List<TutorDto>();
            foreach (var dbEntity in dbEntities)
            {
                entities.Add(await GetDtoFromEntity(dbEntity));
            }

            return entities;
        }

        public async Task<bool> Add(Request<Tutor> request)
        {
            var dbEntity = request.Data;
            dbEntity.Department = await GetDepartment(dbEntity);
            return await AddEntityToDb(dbEntity);
        }

        public async Task<bool> Update(Request<Tutor> request)
        {
            var dbEntity = request.Data;
            dbEntity.Department = await GetDepartment(dbEntity);
            return await UpdateEntityInDb(dbEntity);
        }

        public async Task<bool> Delete(int id)
        {
            var dbEntity = await GetEntity(id);
            return await DeleteEntityFromDb(dbEntity);
        }
    }
}
