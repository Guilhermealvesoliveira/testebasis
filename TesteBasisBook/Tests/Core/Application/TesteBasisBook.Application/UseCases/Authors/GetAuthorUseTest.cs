using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using TesteBasisBook.Application.Test.UseCases.AuthorsManage.Author.Fixtures;
using TesteBasisBook.Application.UseCases.Authors;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using AuthorEntity = TesteBasisBook.Domain.Entity.Author;

namespace TesteBasisBook.Application.UseCases.AuthorsManage.Author
{
    public class GetAuthorUseCaseTest
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly ILogger<GetAuthorUseCase> _logger;
        private const string AuthorNotExistsMessage = "Author not found";
        private const string ExceptionInactivateMessage = "Failed to retrieve entity.";
         private const string AuthorGetSuccessMessage = "Author Get successfully";

        
        public GetAuthorUseCaseTest()
        {
            _AuthorRepository = A.Fake<IAuthorRepository>();
            _logger = A.Fake<ILogger<GetAuthorUseCase>>();
        }

        [Fact]
        public async Task Should_GetAuthor_When_Success()
        {
            // Arrange
            var input = new GetAuthorUseCaseFixture().GetRequest();

            var existingAuthor = new AuthorEntity
            {
                AuthorId = input.AuthorId,
                Name = "Name test"
            };


            A.CallTo(() => _AuthorRepository.GetAsync(input.AuthorId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(existingAuthor));

            var useCase = new GetAuthorUseCase(_AuthorRepository, _logger);

            // Act
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.Message.Should().Be(AuthorGetSuccessMessage);
            response.Data.Should().NotBeNull();
            response.Data.AuthorId.Should().Be(existingAuthor.AuthorId);
            response.Data.Name.Should().Be(existingAuthor.Name);

        }

        [Fact]
        public async Task Should_NotGetAuthor_when_AuthorDoesNotExist_in_database()
        {
            // Arrange
            var input = new GetAuthorUseCaseFixture().GetRequest();

            A.CallTo(() => _AuthorRepository.GetAsync(input.AuthorId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult<AuthorEntity>(null));

            // Act
            var useCase = new GetAuthorUseCase(_AuthorRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(AuthorNotExistsMessage);
            response.BusinessRuleViolation.Should().BeTrue();
        }
        [Fact]
        public async Task Should_HandleException_When_ExceptionThrown()
        {
            // Arrange
            var input = new GetAuthorUseCaseFixture().GetRequest();
            var existingAuthor = new AuthorEntity
            {
                AuthorId = 1,
                Name = "Name test"
            };

            A.CallTo(() => _AuthorRepository.GetAsync(A<int>.Ignored, A<CancellationToken>.Ignored))
                .Throws(new Exception("Database get failed"));

            // Act
            var useCase = new GetAuthorUseCase(_AuthorRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ExceptionInactivateMessage);
        }
    }
}
