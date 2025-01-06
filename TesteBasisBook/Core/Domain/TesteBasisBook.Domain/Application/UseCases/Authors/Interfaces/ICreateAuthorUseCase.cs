using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Authors
{
    public interface ICreateAuthorUseCase
    {
        Task<CreateAuthorOutput> ExecuteAsync(CreateAuthorInput input, CancellationToken cancellationToken);
    }
}
