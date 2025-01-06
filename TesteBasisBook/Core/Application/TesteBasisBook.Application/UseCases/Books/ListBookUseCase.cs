using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Books;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Application.UseCases.Books
{
    public class ListBookUseCase : IListBookUseCase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<ListBookUseCase> _logger;

        public ListBookUseCase(IBookRepository BookRepository, ILogger<ListBookUseCase> logger)
        {
            _logger = logger;
            _bookRepository = BookRepository;
        }

        public async Task<ListBookOutput> ExecuteAsync(ListBookInput input, CancellationToken cancellationToken)
        {
            try
            {
                var books = await _bookRepository.GetAllAsync(cancellationToken);
                if (!books.Any())
                {
                    return new ListBookOutput
                    {
                        IsSuccess = false,
                        Message = "No Book has been registered"
                    };
                }

                var Books = await _bookRepository.GetAllAsync(cancellationToken);

                var ListBooks = new List<ListBookOutputData>();

                foreach (var Book in Books)
                {
                    ListBooks.Add(
                        new ListBookOutputData
                        {
                            BookId = Book.BookId,
                            Edition = Book.Edition,
                            PublicationYear = Book.PublicationYear,
                            Publisher = Book.Publisher,
                            Title = Book.Title,
                        });
                }

                return new ListBookOutput
                {
                    IsSuccess = true,
                    Data = ListBooks,
                    Message = "Get list successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ListBookOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
