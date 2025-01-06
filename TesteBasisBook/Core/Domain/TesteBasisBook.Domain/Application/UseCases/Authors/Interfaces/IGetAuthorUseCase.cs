using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Authors
{
    public interface IGetAuthorUseCase
    {
        Task<GetAuthorOutput> ExecuteAsync(GetAuthorInput input, CancellationToken cancellationToken);
    }
}
