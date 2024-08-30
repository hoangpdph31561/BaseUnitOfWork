using BaseUnitOfWork.Application.ValueObjects.Request;
using BaseUnitOfWork.Application.ValueObjects.Response;
using System.Linq.Expressions;

namespace BaseUnitOfWork.Application.Interfaces.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false, CancellationToken cancellationToken = default);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false, CancellationToken cancellationToken = default);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<PaginatedResult<T>> GetWithPaginationAsync(PaginationRequest paginationRequest, Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false, CancellationToken cancellationToken = default);
    }
}
