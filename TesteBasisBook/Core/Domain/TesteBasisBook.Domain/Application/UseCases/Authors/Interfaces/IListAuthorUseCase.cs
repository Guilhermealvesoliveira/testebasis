using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Authors
{
    public interface IListAuthorUseCase
    {
        Task<ListAuthorOutput> ExecuteAsync(ListAuthorInput input, CancellationToken cancellationToken);
    }
}
