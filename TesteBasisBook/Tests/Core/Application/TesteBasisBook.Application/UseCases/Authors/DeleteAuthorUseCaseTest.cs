using FakeItEasy;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using AuthorEntity = TesteBasisBook.Domain.Entity.Author;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Application.Test.UseCases.UsersManage.User.Fixtures;
using TesteBasisBook.Application.UseCases.Authors;

namespace TesteBasisBook.Application.UseCases.AuthorsManage.Author
{
    public class DeleteAuthorUseCaseTest
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly ILogger<DeleteAuthorUseCase> _logger;
        private const string AuthorInactivateSuccessMessage = "Author deleted successfully";
        private const string AuthorNotExistsMessage = "Author not found";
        private const string ExceptionInactivateMessage = "Failed to retrieve entity.";

        public DeleteAuthorUseCaseTest()
        {
            _AuthorRepository = A.Fake<IAuthorRepository>();
            _logger = A.Fake<ILogger<DeleteAuthorUseCase>>();
        }

        [Fact]
        public async Task Should_Author_When_Success()
        {
            // Arrange
            var input = new DeleteAuthorUseCaseFixture().InactivateRequest();
            var existingAuthor = new AuthorEntity
            {
                AuthorId = 1,
                Name = "Name test"
            };

            A.CallTo(() => _AuthorRepository.GetAsync(existingAuthor.AuthorId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(existingAuthor));
            A.CallTo(() => _AuthorRepository.UpdateAsync(existingAuthor, A<CancellationToken>.Ignored))
                .Returns(Task.CompletedTask);

            // Act
            var useCase = new DeleteAuthorUseCase(_AuthorRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Message.Should().Be(AuthorInactivateSuccessMessage);
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Should_NotAuthor_When_AuthorDoesNotExist()
        {
            // Arrange
            var input = new DeleteAuthorUseCaseFixture().InactivateRequest();

            A.CallTo(() => _AuthorRepository.GetAsync(input.AuthorId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult<AuthorEntity>(null));

            // Act
            var useCase = new DeleteAuthorUseCase(_AuthorRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Message.Should().Be(AuthorNotExistsMessage);
            response.IsSuccess.Should().BeFalse();
            response.BusinessRuleViolation.Should().BeTrue();
        }

        [Fact]
        public async Task Should_HandleException_When_ExceptionThrown()
        {
            // Arrange
            var input = new DeleteAuthorUseCaseFixture().InactivateRequest();
            var existingAuthor = new AuthorEntity
            {
                AuthorId = 1,
                Name = "Name test"
            };
         
            A.CallTo(() => _AuthorRepository.DeleteAsync(A<int>.Ignored, A<CancellationToken>.Ignored))
                .Throws(new Exception("Database update failed"));

            // Act
            var useCase = new DeleteAuthorUseCase(_AuthorRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ExceptionInactivateMessage);
        }
    }
}
