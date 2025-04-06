using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Core;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student, AddStudentResponse, UpdateStudentResponse, DeleteStudentResponse>
    {
        public StudentRepository(ThesisHubContext context) : base(context) { }

        public async Task<List<StudentDto>> GetAll(string filter = "")
        {
            List<Student> dbEntities = await GetAllEntities();

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                dbEntities = dbEntities.Where(d => d.FirstName.ToLower().Contains(filter)).ToList();
            }

            var entities = dbEntities.Select(entity => new StudentDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Phone = entity.Phone,
                DepartmentId = entity.DepartmentId,
            }).ToList();

            return entities;
        }

        public async Task<StudentDto> Get(int id)
        {
            var dbEntity = await GetEntity(id);
            return new StudentDto
            {
                Id = dbEntity.Id,
                FirstName = dbEntity.FirstName,
                LastName = dbEntity.LastName,
                Email = dbEntity.Email,
                Phone = dbEntity.Phone,
                DepartmentId = dbEntity.DepartmentId,
            };
        }

        public async Task<AddStudentResponse> Add(AddStudentRequest request)
        {
            var dbEntity = new Student
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                DepartmentId = request.DepartmentId,
            };

            return await AddEntityToDb(dbEntity);
        }

        public async Task<UpdateStudentResponse> Update(UpdateStudentRequest request)
        {
            var dbEntity = new Student
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                DepartmentId = request.DepartmentId,
            };

            return await UpdateEntityInDb(dbEntity);
        }

        public async Task<DeleteStudentResponse> Delete(int id)
        {
            var dbEntity = await GetEntity(id);
            return await DeleteEntityFromDb(dbEntity);
        }
    }
}
