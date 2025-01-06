using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypes.DeleteSaleType
{
    public interface IDeleteSaleTypeUseCase
    {
        Task<DeleteSaleTypeOutput> ExecuteAsync(DeleteSaleTypeInput input, CancellationToken cancellationToken);
    }
}
