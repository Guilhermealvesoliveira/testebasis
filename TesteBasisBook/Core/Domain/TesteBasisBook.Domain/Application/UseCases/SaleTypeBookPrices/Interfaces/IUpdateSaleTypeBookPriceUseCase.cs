using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.UpdateSaleTypeBookPrice
{
    public interface IUpdateSaleTypeBookPriceUseCase
    {
        Task<UpdateSaleTypeBookPriceOutput> ExecuteAsync(UpdateSaleTypeBookPriceInput input, CancellationToken cancellationToken);
    }
}
