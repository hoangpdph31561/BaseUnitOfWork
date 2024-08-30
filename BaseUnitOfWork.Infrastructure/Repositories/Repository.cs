using BaseUnitOfWork.Application.Interfaces.IRepositories;
using BaseUnitOfWork.Application.ValueObjects.Request;
using BaseUnitOfWork.Application.ValueObjects.Response;
using BaseUnitOfWork.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaseUnitOfWork.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this._dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query;
            //Nếu tracked = true thì theo dõi thay đổi của entity
            if (tracked)
            {
                query = _dbSet;
            }
            else
            {
                query = _dbSet.AsNoTracking();
            }
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = _dbSet;
            }
            else
            {
                query = _dbSet.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync(cancellationToken);
        }
        public async Task<PaginatedResult<T>> GetWithPaginationAsync(PaginationRequest paginationRequest, Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = _dbSet;
            }
            else
            {
                query = _dbSet.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            int totalCount = await query.CountAsync(cancellationToken);
            var data = await query.Skip((paginationRequest.Page - 1) * paginationRequest.PageSize)
                                  .Take(paginationRequest.PageSize)
                                  .ToListAsync(cancellationToken);

            PaginatedResult<T> paginatedResult = new()
            {
                Page = paginationRequest.Page,
                PageSize = paginationRequest.PageSize,
                TotalCount = totalCount,
                Data = data
            };
            return paginatedResult;
        }
    }
}
