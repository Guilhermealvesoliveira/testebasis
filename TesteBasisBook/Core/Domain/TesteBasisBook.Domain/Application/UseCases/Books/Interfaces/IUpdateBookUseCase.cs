using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;

namespace TesteBasisBook.Domain.Application.UseCases.Books
{
    public interface IUpdateBookUseCase
    {
        Task<UpdateBookOutput> ExecuteAsync(UpdateBookInput input, CancellationToken cancellationToken);
    }
}