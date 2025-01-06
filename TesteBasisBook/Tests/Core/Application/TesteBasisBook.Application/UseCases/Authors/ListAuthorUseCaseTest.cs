using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using TesteBasisBook.Application.Test.UseCases.AuthorsManage.Author.Fixtures;
using TesteBasisBook.Application.UseCases.Authors;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using AuthorEntity = TesteBasisBook.Domain.Entity.Author;

namespace TesteBasisBook.Application.UseCases.AuthorsManage.Author
{
    public class ListAuthorUseCaseTests
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly ILogger<ListAuthorUseCase> _logger;
        private const string ListAuthorSuccessMessage = "Get list successfully";
        private const string ListAuthorNotExistsMessage = "No Author has been registered";
        private const string ExceptionListAuthorMessage = "Failed to retrieve entity.";
        public ListAuthorUseCaseTests()
        {
            _AuthorRepository = A.Fake<IAuthorRepository>();
            _logger = A.Fake<ILogger<ListAuthorUseCase>>();
        }

        [Fact]
        public async Task Should_ListAuthors_When_AuthorsExist()
        {
            // Arrange
            var fixture = new ListAuthorUseCaseFixture();
            var input = fixture.CreateRequest();
            var expectedAuthors = new List<AuthorEntity>()
            {
                new AuthorEntity
                {
                    Name = "Name test",
                    AuthorId = 1
                },
                new AuthorEntity
                {
                    Name = "Name test 2",
                    AuthorId = 2
                },
            };
            A.CallTo(() => _AuthorRepository.GetAllAsync(A<CancellationToken>.Ignored)).Returns(expectedAuthors);

            var useCase = new ListAuthorUseCase(_AuthorRepository, _logger);

            // Act
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.Data.Should().HaveCount(expectedAuthors.Count);
            response.Message.Should().Be(ListAuthorSuccessMessage);

        }

        [Fact]
        public async Task Should_ReturnNoAuthors_When_NoAuthorsExist()
        {
            // Arrange
            var fixture = new ListAuthorUseCaseFixture();
            var input = fixture.CreateRequest();

            var useCase = new ListAuthorUseCase(_AuthorRepository, _logger);

            // Act
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ListAuthorNotExistsMessage);
        }

        [Fact]
        public async Task Should_HandleException_When_ExceptionThrown()
        {
            // Arrange
            var fixture = new ListAuthorUseCaseFixture();
            var input = fixture.CreateRequest();
            A.CallTo(() => _AuthorRepository.GetAllAsync( A<CancellationToken>.Ignored))
                .Throws(new Exception("Database error"));

            var useCase = new ListAuthorUseCase(_AuthorRepository, _logger);

            // Act
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ExceptionListAuthorMessage);
        }
    }
}
