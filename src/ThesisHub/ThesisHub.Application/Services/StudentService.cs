using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Common.Responses;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;

namespace ThesisHub.Application.Services
{
    public class StudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _repo;

        public StudentService(IUnitOfWork unitOfWork, IStudentRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        private static Request<Student> GetRequestFromDto(StudentDto request)
        {
            var dbEntity = new Student
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                DepartmentId = request.DepartmentId
            };

            return new Request<Student> { Data = dbEntity };
        }

        public async Task<StudentDto> Get(int id)
        {
            return await _repo.Get(id);
        }

        public async Task<List<StudentDto>> GetAll(string filter = "")
        {
            return await _repo.GetAll(filter);
        }

        public async Task<Response<Student>> Add(StudentDto dto)
        {
            var response = new Response<Student> { Success = false };

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var request = GetRequestFromDto(dto);
                var repo_response = await _repo.Add(request);

                await _unitOfWork.CompleteAsync();
                await _unitOfWork.CommitTransactionAsync();

                response.Success = true;
                response.Message = repo_response.Message;
            }
            catch (Exception e)
            {
                response.Message = $"Creation error! {e}";
                await _unitOfWork.RollbackTransactionAsync();
            }

            return response;
        }

        public async Task<Response<Student>> Update(StudentDto dto)
        {
            var response = new Response<Student> { Success = false };

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var request = GetRequestFromDto(dto);
                var repo_response = await _repo.Update(request);

                await _unitOfWork.CompleteAsync();
                await _unitOfWork.CommitTransactionAsync();

                response.Success = true;
                response.Message = repo_response.Message;
            }
            catch (Exception e)
            {
                response.Message = $"Updating error! {e}";
                await _unitOfWork.RollbackTransactionAsync();
            }

            return response;
        }

        public async Task<Response<Student>> Delete(int id)
        {
            var response = new Response<Student> { Success = false };

            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var repo_response = await _repo.Delete(id);

                await _unitOfWork.CompleteAsync();
                await _unitOfWork.CommitTransactionAsync();

                response.Success = true;
                response.Message = repo_response.Message;
            }
            catch (Exception e)
            {
                response.Message = $"Deleting error! {e}";
                await _unitOfWork.RollbackTransactionAsync();
            }

            return response;
        }
    }
}
