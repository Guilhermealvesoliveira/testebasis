using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.CreateSaleTypeBookPrice
{
    public interface ICreateSaleTypeBookPriceUseCase
    {
        Task<CreateSaleTypeBookPriceOutput> ExecuteAsync(CreateSaleTypeBookPriceInput input, CancellationToken cancellationToken);
    }
}
