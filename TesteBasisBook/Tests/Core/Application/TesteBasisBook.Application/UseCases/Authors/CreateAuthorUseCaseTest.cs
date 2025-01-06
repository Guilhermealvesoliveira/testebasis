using FakeItEasy;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using TesteBasisBook.Application.Test.UseCases.AuthorsManage.Author.Fixtures;
using AuthorEntity = TesteBasisBook.Domain.Entity.Author;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Application.UseCases.Authors;

namespace TesteBasisBook.Application.UseCases.AuthorsManage.Author
{
    public class CreateAuthorUseCaseTest
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly ILogger<CreateAuthorUseCase> _logger;

        private const string AuthorInsertSuccessMessage = "Author saved successfully";
        private const string AuthorExistsMessage = "Author already";
        private const string ExceptionCreationMessage = "Failed to retrieve Author.";

        public CreateAuthorUseCaseTest()
        {
            _AuthorRepository = A.Fake<IAuthorRepository>();
            _logger = A.Fake<ILogger<CreateAuthorUseCase>>();
        }

        [Fact]
        public async Task Should_CreateAuthor_When_Success()
        {
            //Arrange
           var input = new CreateAuthorUseCaseFixture().CreateRequest();
            A.CallTo(() => _AuthorRepository.InsertAsync(A<AuthorEntity>.Ignored, A<CancellationToken>.Ignored)).Returns(1);
            A.CallTo(() => _AuthorRepository.GetAuthorByNameAsync(A<string>.Ignored, A<CancellationToken>.Ignored)).Returns(null as AuthorEntity);


            //Act
            var useCase = new CreateAuthorUseCase(_AuthorRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.Message.Should().Be(AuthorInsertSuccessMessage);
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Should_NotCreateAuthor_When_AuthorExists()
        {
            //Arrange
            var input = new CreateAuthorUseCaseFixture().CreateRequest();
            var mockAuthor = new AuthorEntity
            {
                Name = input.Name,
                AuthorId = 1
            };
            A.CallTo(() => _AuthorRepository.GetAuthorByNameAsync(A<string>.Ignored, A<CancellationToken>.Ignored)).Returns(mockAuthor);


            //Act
            var useCase = new CreateAuthorUseCase(_AuthorRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.Message.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.BusinessRuleViolation.Should().BeTrue();
            response.Message.Should().Contain(AuthorExistsMessage);
        }

        

        [Fact]
        public async Task Should_HandleException_When_ExceptionThrown()
        {
            //Arrange
           var input = new CreateAuthorUseCaseFixture().CreateRequest();

            A.CallTo(() => _AuthorRepository.InsertAsync(A<AuthorEntity>.Ignored, A<CancellationToken>.Ignored)).Throws(new Exception());
            A.CallTo(() => _AuthorRepository.GetAuthorByNameAsync(A<string>.Ignored, A<CancellationToken>.Ignored)).Returns(null as AuthorEntity);

            //Act
            var useCase = new CreateAuthorUseCase(_AuthorRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ExceptionCreationMessage);
        }
    }
}