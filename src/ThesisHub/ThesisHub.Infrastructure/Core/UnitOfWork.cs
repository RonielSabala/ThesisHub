using Microsoft.EntityFrameworkCore.Storage;
using ThesisHub.Domain.Entities;
using ThesisHub.Infrastructure.Contracts;
using ThesisHub.Infrastructure.Repositories;
using ThesisHub.Persistence;

namespace ThesisHub.Infrastructure.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ThesisHubContext _context;
        private IDbContextTransaction _transaction;

        private IRepository<Department> _departments;
        private IRepository<Student> _students;

        public IRepository<Department> Departments => _departments ??= new DepartmentRepository(_context);
        public IRepository<Student> Students => _students ??= new StudentRepository(_context);

        public UnitOfWork(ThesisHubContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}