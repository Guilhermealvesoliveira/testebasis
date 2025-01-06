using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypes.UpdateSaleType
{
    public interface IUpdateSaleTypeUseCase
    {
        Task<UpdateSaleTypeOutput> ExecuteAsync(UpdateSaleTypeInput input, CancellationToken cancellationToken);
    }
}
