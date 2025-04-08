using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;

namespace ThesisHub.Application.Services
{
    public class DepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentRepository _repo;

        public DepartmentService(IUnitOfWork unitOfWork, IDepartmentRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        private static Request<Department> GetRequestFromDto(DepartmentDto request)
        {
            var dbEntity = new Department
            {
                Id = request.Id,
                DeptName = request.DeptName,
                FacultyHead = request.FacultyHead,
                Email = request.Email,
            };

            return new Request<Department> { Data = dbEntity };
        }

        public async Task<DepartmentDto> Get(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<List<DepartmentDto>> GetAll(string filter = "")
        {
            return await _repo.GetAll(filter);
        }

        public async Task<bool> Add(DepartmentDto dto)
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

        public async Task<bool> Update(DepartmentDto dto)
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
