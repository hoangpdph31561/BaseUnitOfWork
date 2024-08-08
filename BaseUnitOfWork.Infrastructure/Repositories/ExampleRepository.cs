using BaseUnitOfWork.Application.Interfaces.IRepositories;
using BaseUnitOfWork.Domain.Entities;
using BaseUnitOfWork.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace BaseUnitOfWork.Infrastructure.Repositories
{
    public class ExampleRepository : Repository<ExampleEntity>, IExampleRepository
    {
        private readonly ApplicationDbContext _context;
        public ExampleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task Update(ExampleEntity example, CancellationToken cancellationToken = default)
        {
            var exampleEntity = await GetExampleById(example.Id, cancellationToken);
            if (exampleEntity != null)
            {
                exampleEntity.Name = example.Name;
                exampleEntity.Description = example.Description;
                exampleEntity.ModifiedBy = example.ModifiedBy;
                exampleEntity.ModifiedTime = DateTimeOffset.UtcNow;
            }
        }
        public async Task Remove(ExampleEntity example, CancellationToken cancellationToken = default)
        {
            var exampleEntity = await GetExampleById(example.Id, cancellationToken);
            if (exampleEntity != null)
            {
                exampleEntity.Deleted = example.Deleted;
                exampleEntity.DeletedTime = DateTimeOffset.UtcNow;
            }
        }
        private async Task<ExampleEntity> GetExampleById(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Examples.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

    }
}
