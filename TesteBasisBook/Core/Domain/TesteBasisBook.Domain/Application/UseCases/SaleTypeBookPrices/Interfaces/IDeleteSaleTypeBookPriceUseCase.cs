using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.DeleteSaleTypeBookPrice
{
    public interface IDeleteSaleTypeBookPriceUseCase
    {
        Task<DeleteSaleTypeBookPriceOutput> ExecuteAsync(DeleteSaleTypeBookPriceInput input, CancellationToken cancellationToken);
    }
}
