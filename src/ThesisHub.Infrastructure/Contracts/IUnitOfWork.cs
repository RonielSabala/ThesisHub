namespace ThesisHub.Infrastructure.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompleteAsync();

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();

        void Dispose();
    }
}