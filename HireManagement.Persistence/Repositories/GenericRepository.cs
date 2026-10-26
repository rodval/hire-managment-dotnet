using HireManagement.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HireManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HireManagementDbContext _dbContext;

        public GenericRepository(HireManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> Get(int id, CancellationToken cancellationToken = default) =>
            await _dbContext.Set<T>().FindAsync([id], cancellationToken);

        public async Task<T?> Get(string id, CancellationToken cancellationToken = default) =>
            await _dbContext.Set<T>().FindAsync([id], cancellationToken);

        public async Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default) =>
            await _dbContext.Set<T>().ToListAsync(cancellationToken);

        public async Task<T> Add(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(entity, cancellationToken);
            return entity;
        }

        public void Update(T entity) =>
            _dbContext.Entry(entity).State = EntityState.Modified;

        public void Delete(T entity) =>
            _dbContext.Set<T>().Remove(entity);
    }
}
