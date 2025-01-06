using Microsoft.Extensions.Logging;
using TesteBasisBook.Domain.Application.UseCases.Books.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Books.Outputs;
using TesteBasisBook.Domain.Application.UseCases.Books;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Domain.Entity;

namespace TesteBasisBook.Application.UseCases.Books
{
    public class UpdateBookUseCase : IUpdateBookUseCase
    {
        private readonly IBookRepository _BookRepository;
        private readonly IAuthorBookRepository _authorBookRepository;
        private readonly ISubjectBookRepository _subjectBookRepository;
        private readonly ILogger<UpdateBookUseCase> _logger;

        public UpdateBookUseCase(IBookRepository BookRepository, IAuthorBookRepository authorBookRepository, ISubjectBookRepository subjectBookRepository, ILogger<UpdateBookUseCase> logger)
        {
            _logger = logger;
            _BookRepository = BookRepository;
            _authorBookRepository = authorBookRepository;
            _subjectBookRepository = subjectBookRepository;
        }

        public async Task<UpdateBookOutput> ExecuteAsync(UpdateBookInput input, CancellationToken cancellationToken)
        {
            try
            {
                var book = await _BookRepository.GetAsync(input.BookId, cancellationToken);
                if (book == default)
                {
                    return new UpdateBookOutput
                    {
                        IsSuccess = false,
                        BusinessRuleViolation = true,
                        Message = "Book not found",

                    };
                }

                book.Title = input.Title;
                book.Edition = input.Edition;
                book.Publisher = input.Publisher;
                book.PublicationYear = input.PublicationYear;

                await _BookRepository.UpdateAsync(book, cancellationToken);


                await _authorBookRepository.DeleteAuthorsByBook(book.BookId, cancellationToken);

                foreach (var authorId in input.AuthorsId)
                {
                    var newAuthorBook = new AuthorBook
                    {
                        AuthorId = authorId,
                        BookId = book.BookId
                    };

                    await _authorBookRepository.InsertAsync(newAuthorBook, cancellationToken);

                }

                await _subjectBookRepository.DeleteSubjectsByBook(book.BookId, cancellationToken);

                foreach (var subjectIdId in input.SubjectsId)
                {
                    var newSubjectBook = new SubjectBook
                    {
                        SubjectId = subjectIdId,
                        BookId = book.BookId
                    };

                    await _subjectBookRepository.InsertAsync(newSubjectBook, cancellationToken);

                }

                return new UpdateBookOutput
                {
                    IsSuccess = true,
                    Message = "Book updated successfully"

                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new UpdateBookOutput
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve entity."
                };
            }
        }
    }
}
