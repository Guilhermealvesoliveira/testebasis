using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using TesteBasisBook.Application.Test.UseCases.AuthorsManage.Author.Fixtures;
using TesteBasisBook.Application.UseCases.Authors;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using AuthorEntity = TesteBasisBook.Domain.Entity.Author;

namespace TesteBasisBook.Application.UseCases.AuthorsManage.Author
{
    public class UpdateAuthorUseCaseTest
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly ILogger<UpdateAuthorUseCase> _logger;

        private const string AuthorUpdateSuccessMessage = "Author updated successfully";
        private const string AuthorNotExistsMessage = "Author not found";
        private const string ExceptionUpdateMessage = "Failed to retrieve entity.";
        public UpdateAuthorUseCaseTest()
        {
            _AuthorRepository = A.Fake<IAuthorRepository>();
            _logger = A.Fake<ILogger<UpdateAuthorUseCase>>();
        }
        [Fact]
        public async Task Should_UpdateAuthor_When_Success()
        {
            // Arrange
            var input = new UpdateAuthorUseCaseFixture().UpdateRequest();
            var existingAuthor = new AuthorEntity
            {
                AuthorId = input.AuthorId,
                Name = input.Name,
            };

            A.CallTo(() => _AuthorRepository.GetAsync(existingAuthor.AuthorId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(existingAuthor));
            A.CallTo(() => _AuthorRepository.UpdateAsync(A<AuthorEntity>.Ignored, A<CancellationToken>.Ignored))
                .Returns(Task.CompletedTask);

            // Act
            var useCase = new UpdateAuthorUseCase(_AuthorRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Message.Should().Be(AuthorUpdateSuccessMessage);
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Should_NotUpdateAuthor_When_AuthorDoesNotExist()
        {
            // Arrange
            var input = new UpdateAuthorUseCaseFixture().UpdateRequest();
            A.CallTo(() => _AuthorRepository.GetAsync(input.AuthorId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(null as AuthorEntity));

            // Act
            var useCase = new UpdateAuthorUseCase(_AuthorRepository, _logger);
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
            var input = new UpdateAuthorUseCaseFixture().UpdateRequest();
            var existingAuthor = new AuthorEntity
            {
                AuthorId = input.AuthorId,
                Name = "test",
            };
            A.CallTo(() => _AuthorRepository.GetAsync(input.AuthorId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(existingAuthor));

            A.CallTo(() => _AuthorRepository.UpdateAsync(A<AuthorEntity>.Ignored, A<CancellationToken>.Ignored))
                .Throws(new Exception("Database update failed"));
            // Act
            var useCase = new UpdateAuthorUseCase(_AuthorRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);
            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ExceptionUpdateMessage);
        }
    }
}
