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

        public async Task UpdateEntityDepartment(Student dbEntity)
        {
            var department = await Context.Departments.FindAsync(dbEntity.DepartmentId);
            dbEntity.Department = department;
        }

        public async Task<StudentDto> Get(int id)
        {
            var dbEntity = await GetEntity(id);
            if (dbEntity.Department == null)
            {
                await UpdateEntityDepartment(dbEntity);
            }
            
            return new StudentDto
            {
                Id = dbEntity.Id,
                FirstName = dbEntity.FirstName,
                LastName = dbEntity.LastName,
                Email = dbEntity.Email,
                Phone = dbEntity.Phone,
                DepartmentId = dbEntity.DepartmentId,
                DeptName = dbEntity.Department.DeptName,
            };
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
                if (dbEntity.Department == null)
                {
                    await UpdateEntityDepartment(dbEntity);
                }

                entities.Add(new StudentDto
                {
                    Id = dbEntity.Id,
                    FirstName = dbEntity.FirstName,
                    LastName = dbEntity.LastName,
                    Email = dbEntity.Email,
                    Phone = dbEntity.Phone,
                    DepartmentId = dbEntity.DepartmentId,
                    DeptName = dbEntity.Department.DeptName,
                });
            }

            return entities;
        }

        public async Task<bool> Add(Request<Student> request)
        {
            var dbEntity = request.Data;
            await UpdateEntityDepartment(dbEntity);
            return await AddEntityToDb(dbEntity);
        }

        public async Task<bool> Update(Request<Student> request)
        {
            var dbEntity = request.Data;
            await UpdateEntityDepartment(dbEntity);
            return await UpdateEntityInDb(dbEntity);
        }

        public async Task<bool> Delete(int id)
        {
            var dbEntity = await GetEntity(id);
            return await DeleteEntityFromDb(dbEntity);
        }
    }
}
