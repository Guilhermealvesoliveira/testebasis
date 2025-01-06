using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.ListSaleTypeBookPrice
{
    public interface IListSaleTypeBookPriceUseCase
    {
        Task<ListSaleTypeBookPriceOutput> ExecuteAsync(ListSaleTypeBookPriceInput input, CancellationToken cancellationToken);
    }
}
