using ThesisHub.Application.Contracts;
using ThesisHub.Common.Dtos;
using ThesisHub.Common.Requests;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;

namespace ThesisHub.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDocumentRepository _repo;

        public DocumentService(IUnitOfWork unitOfWork, IDocumentRepository repo)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        private Request<Document> GetRequestFromDto(DocumentDto dto)
        {
            var dbEntity = new Document
            {
                Id = dto.Id,
                DocName = dto.DocName,
                FilePath = dto.FilePath,
                UploadDate = dto.UploadDate,
                DocStatus = dto.DocStatus,
                ProjectId = dto.ProjectId,
            };

            return new Request<Document> { Data = dbEntity };
        }

        public async Task<DocumentDto> Get(int id)
        {
            await _unitOfWork.BeginTransactionAsync();

            var dto = await _repo.Get(id);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();

            return dto;
        }

        public async Task<List<DocumentDto>> GetAll(string filter = "")
        {
            await _unitOfWork.BeginTransactionAsync();

            var dtos = await _repo.GetAll(filter);

            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitTransactionAsync();

            return dtos;
        }

        public async Task<bool> Add(DocumentDto dto)
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

        public async Task<bool> Update(DocumentDto dto)
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
