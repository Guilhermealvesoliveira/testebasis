using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs;
using TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypes.ListSaleType
{
    public interface IListSaleTypeUseCase
    {
        Task<ListSaleTypeOutput> ExecuteAsync(ListSaleTypeInput input, CancellationToken cancellationToken);
    }
}
