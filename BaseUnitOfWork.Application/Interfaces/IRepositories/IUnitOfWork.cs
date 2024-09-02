namespace BaseUnitOfWork.Application.Interfaces.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IExampleRepository Example { get; }
        Task SaveAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}
