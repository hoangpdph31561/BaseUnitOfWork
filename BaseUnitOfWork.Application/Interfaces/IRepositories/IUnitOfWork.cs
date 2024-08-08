namespace BaseUnitOfWork.Application.Interfaces.IRepositories
{
    public interface IUnitOfWork
    {
        IExampleRepository Example { get; }
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}
