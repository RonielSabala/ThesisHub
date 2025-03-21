using Microsoft.EntityFrameworkCore;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Interfaces;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ThesisHubContext _context;

        public StudentRepository(ThesisHubContext context)
        {
            _context = context;
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

        public async Task<List<StudentDto>> GetAll(string filter = "")
        {
            var entitiesDb = await _context.Students.ToListAsync();
            if (!entitiesDb.Any())
            {
                throw new Exception("No data found");
            }

            if (!string.IsNullOrEmpty(filter))
            {
                filter = filter.ToLower();
                entitiesDb = entitiesDb.Where(d => d.FirstName.ToLower().Contains(filter)).ToList();
            }

            var entities = entitiesDb.Select(entity => new StudentDto
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
            var entityDb = await _context.Students.FindAsync(id);
            if (entityDb == null)
            {
                throw new Exception("Not found");
            }

            return new StudentDto
            {
                Id = entityDb.Id,
                FirstName = entityDb.FirstName,
                LastName = entityDb.LastName,
                Email = entityDb.Email,
                Phone = entityDb.Phone,
                DepartmentId = entityDb.DepartmentId,
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

            _context.Students.Add(dbEntity);
            await _context.SaveChangesAsync();
            return new AddStudentResponse();
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

            try
            {
                _context.Update(dbEntity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(dbEntity.Id))
                {
                    throw new Exception("Not found");
                }
                else
                {
                    throw;
                }
            }

            return new UpdateStudentResponse();
        }

        public async Task<DeleteStudentResponse> Delete(int id)
        {
            var entityDb = await _context.Students.FindAsync(id);
            if (entityDb == null)
            {
                throw new Exception("Not found");
            }

            _context.Students.Remove(entityDb);
            await _context.SaveChangesAsync();
            return new DeleteStudentResponse();
        }
    }
}
