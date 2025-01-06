namespace TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetAsync(object id, CancellationToken cancellationToken = default);
        Task<int> InsertAsync(T t, CancellationToken cancellationToken = default);
        Task UpdateAsync(T t, CancellationToken cancellationToken = default);
        Task DeleteAsync(object id, CancellationToken cancellationToken = default);
        Task InsertRangeAsync(IEnumerable<T> t, CancellationToken cancellationToken = default);
    }
}
