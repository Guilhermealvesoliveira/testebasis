using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Authors
{
    public interface IDeleteAuthorUseCase
    {
        Task<DeleteAuthorOutput> ExecuteAsync(DeleteAuthorInput input, CancellationToken cancellationToken);
    }
}
