using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;
using ThesisHub.Infrastructure.Core;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(DataContext context) : base(context) { }

        public async Task<Department> GetDepartment(Student dbEntity)
        {
            return await Context.Departments.FindAsync(dbEntity.DepartmentId);
        }

        public async Task<StudentDto> GetDtoFromEntity(Student dbEntity)
        {
            var department = dbEntity.Department;
            if (department == null)
            {
                department = await GetDepartment(dbEntity);
                dbEntity.Department = department;
            }

            return new StudentDto
            {
                Id = dbEntity.Id,
                FirstName = dbEntity.FirstName,
                LastName = dbEntity.LastName,
                Email = dbEntity.Email,
                Phone = dbEntity.Phone,
                DepartmentId = department.Id,
                DeptName = department.DeptName,
            };
        }

        public async Task<StudentDto> Get(int id)
        {
            var dbEntity = await GetEntity(id);
            return await GetDtoFromEntity(dbEntity);
        }

        public async Task<List<StudentDto>> GetAll(string filter = "")
        {
            var dbEntities = await GetAllEntities();
            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                dbEntities = dbEntities.Where(d => d.FirstName.ToLower().Contains(filter)).ToList();
            }

            var entities = new List<StudentDto>();
            foreach (var dbEntity in dbEntities)
            {
                entities.Add(await GetDtoFromEntity(dbEntity));
            }

            return entities;
        }

        public async Task<bool> Add(Request<Student> request)
        {
            var dbEntity = request.Data;
            dbEntity.Department = await GetDepartment(dbEntity);
            return await AddEntityToDb(dbEntity);
        }

        public async Task<bool> Update(Request<Student> request)
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
