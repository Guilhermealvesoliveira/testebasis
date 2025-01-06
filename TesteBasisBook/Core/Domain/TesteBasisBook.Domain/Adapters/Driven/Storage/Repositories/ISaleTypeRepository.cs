
using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories
{
    public interface ISaleTypeRepository : IGenericRepositoryAsync<SaleType>
    {
        Task<SaleType> GetSaleTypeByDescriptionAsync(string description, CancellationToken cancellationToken);
    }
}