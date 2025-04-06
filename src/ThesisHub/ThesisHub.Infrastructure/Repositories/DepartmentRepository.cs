using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Core;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department, AddDepartmentResponse, UpdateDepartmentResponse, DeleteDepartmentResponse>
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

            var entities = dbEntities.Select(entity => new DepartmentDto
            {
                Id = entity.Id,
                DeptName = entity.DeptName,
                FacultyHead = entity.FacultyHead,
                Email = entity.Email
            }).ToList();

            return entities;
        }

        public async Task<AddDepartmentResponse> Add(AddDepartmentRequest request)
        {
            var dbEntity = new Department
            {
                Id = request.Id,
                DeptName = request.DeptName,
                FacultyHead = request.FacultyHead,
                Email = request.Email,
            };

            return await AddEntityToDb(dbEntity);
        }

        public async Task<UpdateDepartmentResponse> Update(UpdateDepartmentRequest request)
        {
            var dbEntity = new Department
            {
                Id = request.Id,
                DeptName = request.DeptName,
                FacultyHead = request.FacultyHead,
                Email = request.Email,
            };

            return await UpdateEntityInDb(dbEntity);
        }

        public async Task<DeleteDepartmentResponse> Delete(int id)
        {
            var dbEntity = await GetEntity(id);
            return await DeleteEntityFromDb(dbEntity);
        }
    }
}
