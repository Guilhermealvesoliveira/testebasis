using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Authors
{
    public interface IUpdateAuthorUseCase
    {
        Task<UpdateAuthorOutput> ExecuteAsync(UpdateAuthorInput input, CancellationToken cancellationToken);
    }
}
