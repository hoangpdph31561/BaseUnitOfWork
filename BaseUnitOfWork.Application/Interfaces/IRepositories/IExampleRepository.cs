using BaseUnitOfWork.Domain.Entities;

namespace BaseUnitOfWork.Application.Interfaces.IRepositories
{
    public interface IExampleRepository : IRepository<ExampleEntity>
    {
        Task Update(ExampleEntity example, CancellationToken cancellationToken = default);
        Task Remove(ExampleEntity example, CancellationToken cancellationToken = default);
    }
}
