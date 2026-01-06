using ThesisHub.Application.Contracts;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;

namespace ThesisHub.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _repo;

        public StudentService(IUnitOfWork unitOfWork, IStudentRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        private Request<Student> GetRequestFromDto(StudentDto dto)
        {
            var dbEntity = new Student
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                DepartmentId = dto.DepartmentId
            };

            return new Request<Student> { Data = dbEntity };
        }

        public async Task<StudentDto> Get(int id)
        {
            await _unitOfWork.BeginTransactionAsync();

            var dto = await _repo.Get(id);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();

            return dto;
        }

        public async Task<List<StudentDto>> GetAll(string filter = "")
        {
            await _unitOfWork.BeginTransactionAsync();

            var dtos = await _repo.GetAll(filter);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();

            return dtos;
        }

        public async Task<bool> Add(StudentDto dto)
        {
            bool response = false;

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var request = GetRequestFromDto(dto);
                response = await _repo.Add(request);

                await _unitOfWork.CompleteAsync();
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
            }

            return response;
        }

        public async Task<bool> Update(StudentDto dto)
        {
            bool response = false;

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var request = GetRequestFromDto(dto);
                response = await _repo.Update(request);

                await _unitOfWork.CompleteAsync();
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
            }

            return response;
        }

        public async Task<bool> Delete(int id)
        {
            bool response = false;

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                response = await _repo.Delete(id);

                await _unitOfWork.CompleteAsync();
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync();
            }

            return response;
        }
    }
}
