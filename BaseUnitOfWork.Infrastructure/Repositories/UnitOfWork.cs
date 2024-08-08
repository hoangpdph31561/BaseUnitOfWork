using BaseUnitOfWork.Application.Interfaces.IRepositories;
using BaseUnitOfWork.Infrastructure.Database.AppDbContext;

namespace BaseUnitOfWork.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IExampleRepository Example { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Example = new ExampleRepository(context);
        }
        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
