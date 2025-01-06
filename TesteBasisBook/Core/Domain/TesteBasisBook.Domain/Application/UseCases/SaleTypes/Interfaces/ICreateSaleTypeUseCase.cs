using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypes.CreateSaleType
{
    public interface ICreateSaleTypeUseCase
    {
        Task<CreateSaleTypeOutput> ExecuteAsync(CreateSaleTypeInput input, CancellationToken cancellationToken);
    }
}
