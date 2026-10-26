namespace HireManagement.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> Get(int id, CancellationToken cancellationToken = default);
        Task<T?> Get(string id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAll(CancellationToken cancellationToken = default);
        Task<T> Add(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);
    }
}
