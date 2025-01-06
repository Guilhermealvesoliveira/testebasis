using TesteBasisBook.Domain.Dtos;
using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories
{
    public interface ISaleTypeBookPriceRepository : IGenericRepositoryAsync<SaleTypeBookPrice>
    {
        Task<IEnumerable<SaleTypeBookPriceDto>> GetSaleTypeBookPriceByBook(int bookId, CancellationToken cancellationToken);
        Task<SaleTypeBookPrice> GetSaleTypeBookPriceByBookAndType(int bookId, int saleTypeId, CancellationToken cancellationToken);
        Task DeleteSaleTypeBookPriceByBookAndType(int bookId, int saleTypeId, CancellationToken cancellationToken);
    }
}