using ThesisHub.Application.Contracts;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;

namespace ThesisHub.Application.Services
{
    public class ProjectTutorService : IProjectTutorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectTutorRepository _repo;

        public ProjectTutorService(IUnitOfWork unitOfWork, IProjectTutorRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        private Request<ProjectTutor> GetRequestFromDto(ProjectTutorDto dto)
        {
            var dbEntity = new ProjectTutor
            {
                Id = dto.Id,
                ProjectId = dto.ProjectId,
                TutorId = dto.TutorId,
                TutorRole = dto.TutorRole,
            };

            return new Request<ProjectTutor> { Data = dbEntity };
        }

        public async Task<ProjectTutorDto> Get(int id)
        {
            await _unitOfWork.BeginTransactionAsync();

            var dto = await _repo.Get(id);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();

            return dto;
        }

        public async Task<List<ProjectTutorDto>> GetAll(string filter = "", bool filterProject = true)
        {
            await _unitOfWork.BeginTransactionAsync();

            var dtos = await _repo.GetAll(filter, filterProject);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();

            return dtos;
        }

        public async Task<bool> Add(ProjectTutorDto dto)
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

        public async Task<bool> Update(ProjectTutorDto dto)
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
