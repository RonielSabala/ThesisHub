using ThesisHub.Application.Contracts;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;

namespace ThesisHub.Application.Services
{
    public class TutorService : ITutorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITutorRepository _repo;

        public TutorService(IUnitOfWork unitOfWork, ITutorRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        private Request<Tutor> GetRequestFromDto(TutorDto dto)
        {
            var dbEntity = new Tutor
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Specialization = dto.Specialization,
                DepartmentId = dto.DepartmentId
            };

            return new Request<Tutor> { Data = dbEntity };
        }

        public async Task<TutorDto> Get(int id)
        {
            await _unitOfWork.BeginTransactionAsync();

            var dto = await _repo.Get(id);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();

            return dto;
        }

        public async Task<List<TutorDto>> GetAll(string filter = "")
        {
            await _unitOfWork.BeginTransactionAsync();

            var dtos = await _repo.GetAll(filter);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();

            return dtos;
        }

        public async Task<bool> Add(TutorDto dto)
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

        public async Task<bool> Update(TutorDto dto)
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
