using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.GetSaleTypeBookPrice
{
    public interface IGetSaleTypeBookPriceUseCase
    {
        Task<GetSaleTypeBookPriceOutput> ExecuteAsync(GetSaleTypeBookPriceInput input, CancellationToken cancellationToken);
    }
}
