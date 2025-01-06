using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Books;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Application.UseCases.Books
{
    public class CreateBookUseCase : ICreateBookUseCase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorBookRepository _authorBookRepository;
        private readonly ISubjectBookRepository _subjectBookRepository;

        private readonly ILogger<CreateBookUseCase> _logger;

        public CreateBookUseCase(IBookRepository bookRepository, IAuthorBookRepository authorBookRepository, ISubjectBookRepository subjectBookRepository, ILogger<CreateBookUseCase> logger)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _authorBookRepository = authorBookRepository;
            _bookRepository = bookRepository;
           _subjectBookRepository = subjectBookRepository;
        }

        public async Task<CreateBookOutput> ExecuteAsync(CreateBookInput input, CancellationToken cancellationToken)
        {
            try
            {
                var newSubjecct = new Book
                {
                   Edition = input.Edition,
                   PublicationYear = input.PublicationYear,
                   Publisher = input.Publisher,
                   Title = input.Title,
                   
                };
                var bookId = await _bookRepository.InsertAsync(newSubjecct, cancellationToken);
                
                foreach(var authorId in input.AuthorsId)
                {
                    var newAuthorBook = new AuthorBook
                    {
                        AuthorId = authorId,
                        BookId = bookId
                    };
                    await _authorBookRepository.InsertAsync(newAuthorBook, cancellationToken);

                }

                foreach (var subjectIdId in input.SubjectsId)
                {
                    var newSubjectBook = new SubjectBook
                    {
                        SubjectId = subjectIdId,
                        BookId = bookId
                    };

                    await _subjectBookRepository.InsertAsync(newSubjectBook, cancellationToken);

                }

                return new CreateBookOutput
                {
                    IsSuccess = true,
                    Message = "Book saved successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new CreateBookOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve Book."
                };
            }
        }
    }
}
