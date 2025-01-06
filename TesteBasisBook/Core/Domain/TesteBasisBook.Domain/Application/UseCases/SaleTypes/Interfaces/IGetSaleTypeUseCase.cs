using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypes.GetSaleType
{
    public interface IGetSaleTypeUseCase
    {
        Task<GetSaleTypeOutput> ExecuteAsync(GetSaleTypeInput input, CancellationToken cancellationToken);
    }
}
