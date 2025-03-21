using Microsoft.EntityFrameworkCore;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Interfaces;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ThesisHubContext _context;

        public DepartmentRepository(ThesisHubContext context)
        {
            _context = context;
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }

        public async Task<List<DepartmentDto>> GetAll(string filter = "")
        {
            var entitiesDb = await _context.Departments.ToListAsync();
            if (!entitiesDb.Any())
            {
                throw new Exception("No data found");
            }

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                entitiesDb = entitiesDb.Where(d => d.DeptName.ToLower().Contains(filter)).ToList();
            }

            var entities = entitiesDb.Select(entity => new DepartmentDto
            {
                Id = entity.Id,
                DeptName = entity.DeptName,
                FacultyHead = entity.FacultyHead,
                Email = entity.Email
            }).ToList();

            return entities;
        }

        public async Task<DepartmentDto> Get(int id)
        {
            var entityDb = await _context.Departments.FindAsync(id);
            if (entityDb == null)
            {
                throw new Exception("Not found");
            }

            return new DepartmentDto
            {
                Id = entityDb.Id,
                DeptName = entityDb.DeptName,
                FacultyHead = entityDb.FacultyHead,
                Email = entityDb.Email,
            };


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

            _context.Departments.Add(dbEntity);
            await _context.SaveChangesAsync();
            return new AddDepartmentResponse();
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

            try
            {
                _context.Update(dbEntity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(dbEntity.Id))
                {
                    throw new Exception("Not found");
                }
                else
                {
                    throw;
                }
            }

            return new UpdateDepartmentResponse();
        }

        public async Task<DeleteDepartmentResponse> Delete(int id)
        {
            var entityDb = await _context.Departments.FindAsync(id);
            if (entityDb == null)
            {
                throw new Exception("Not found");
            }

            _context.Departments.Remove(entityDb);
            await _context.SaveChangesAsync();
            return new DeleteDepartmentResponse();
        }
    }
}
