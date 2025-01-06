using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using TesteBasisBook.Application.Services.Subjects;
using TesteBasisBook.Application.Test.UseCases.SubjectsManage.Subject.Fixtures;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using SubjectEntity = TesteBasisBook.Domain.Entity.Subject;

namespace TesteBasisBook.Application.UseCases.SubjectsManage.Subject
{
    public class ListSubjectUseCaseTests
    {
        private readonly ISubjectRepository _SubjectRepository;
        private readonly ILogger<ListSubjectUseCase> _logger;
        private const string ListSubjectSuccessMessage = "Get list successfully";
        private const string ListSubjectNotExistsMessage = "No subject has been registered";
        private const string ExceptionListSubjectMessage = "Failed to retrieve entity.";
        public ListSubjectUseCaseTests()
        {
            _SubjectRepository = A.Fake<ISubjectRepository>();
            _logger = A.Fake<ILogger<ListSubjectUseCase>>();
        }

        [Fact]
        public async Task Should_ListSubjects_When_SubjectsExist()
        {
            // Arrange
            var fixture = new ListSubjectUseCaseFixture();
            var input = fixture.CreateRequest();
            var expectedSubjects = new List<SubjectEntity>()
            {
                new SubjectEntity
                {
                    Description = "description test",
                    SubjectId = 1
                },
                new SubjectEntity
                {
                    Description = "description test 2",
                    SubjectId = 2
                },
            };
            A.CallTo(() => _SubjectRepository.GetAllAsync(A<CancellationToken>.Ignored)).Returns(expectedSubjects);

            var useCase = new ListSubjectUseCase(_SubjectRepository, _logger);

            // Act
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.Data.Should().HaveCount(expectedSubjects.Count);
            response.Message.Should().Be(ListSubjectSuccessMessage);

        }

        [Fact]
        public async Task Should_ReturnNoSubjects_When_NoSubjectsExist()
        {
            // Arrange
            var fixture = new ListSubjectUseCaseFixture();
            var input = fixture.CreateRequest();

            var useCase = new ListSubjectUseCase(_SubjectRepository, _logger);

            // Act
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ListSubjectNotExistsMessage);
        }

        [Fact]
        public async Task Should_HandleException_When_ExceptionThrown()
        {
            // Arrange
            var fixture = new ListSubjectUseCaseFixture();
            var input = fixture.CreateRequest();
            A.CallTo(() => _SubjectRepository.GetAllAsync( A<CancellationToken>.Ignored))
                .Throws(new Exception("Database error"));

            var useCase = new ListSubjectUseCase(_SubjectRepository, _logger);

            // Act
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ExceptionListSubjectMessage);
        }
    }
}
