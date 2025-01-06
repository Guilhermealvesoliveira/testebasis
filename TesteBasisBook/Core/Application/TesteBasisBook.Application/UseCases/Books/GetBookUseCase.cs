using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Books;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;

namespace TesteBasisBook.Application.UseCases.Books
{
    public class GetBookUseCase : IGetBookUseCase
    {
        private readonly IBookRepository _BookRepository;
        private readonly IAuthorBookRepository _authorBookRepository;
        private readonly ISubjectBookRepository _subjectBookRepository;
        private readonly ILogger<GetBookUseCase> _logger;

        public GetBookUseCase(IBookRepository BookRepository, IAuthorBookRepository authorBookRepository, ISubjectBookRepository subjectBookRepository,  ILogger<GetBookUseCase> logger)
        {
            _logger = logger;
            _BookRepository = BookRepository;
            _authorBookRepository = authorBookRepository;
            _subjectBookRepository = subjectBookRepository;
        }

        public async Task<GetBookOutput> ExecuteAsync(GetBookInput input, CancellationToken cancellationToken)
        {
            try
            {
                var Book = await _BookRepository.GetAsync(input.BookId, cancellationToken);
                if (Book == default)
                {
                    return new GetBookOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "Book not found",

                    };
                }

                return new GetBookOutput
                {
                    IsSuccess = true,
                    Data = new GetBookOutputData
                    {
                        BookId = input.BookId,
                        Edition = Book.Edition,
                        PublicationYear = Book.PublicationYear,
                        Publisher = Book.Publisher,
                        Title = Book.Title,
                        AuthorsId =  await _authorBookRepository.GetAuthorsByBook(input.BookId, cancellationToken),
                        SubjectsId = await _subjectBookRepository.GetSubjectsByBook(input.BookId, cancellationToken)
                    }

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new GetBookOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
