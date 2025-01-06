using FakeItEasy;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using SubjectEntity = TesteBasisBook.Domain.Entity.Subject;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Application.Services.Subjects;
using TesteBasisBook.Application.Test.UseCases.UsersManage.User.Fixtures;

namespace TesteBasisBook.Application.UseCases.SubjectsManage.Subject
{
    public class DeleteSubjectUseCaseTest
    {
        private readonly ISubjectRepository _SubjectRepository;
        private readonly ILogger<DeleteSubjectUseCase> _logger;
        private const string SubjectInactivateSuccessMessage = "Subject deleted successfully";
        private const string SubjectNotExistsMessage = "Subject not found";
        private const string ExceptionInactivateMessage = "Failed to retrieve entity.";

        public DeleteSubjectUseCaseTest()
        {
            _SubjectRepository = A.Fake<ISubjectRepository>();
            _logger = A.Fake<ILogger<DeleteSubjectUseCase>>();
        }

        [Fact]
        public async Task Should_Subject_When_Success()
        {
            // Arrange
            var input = new DeleteSubjectUseCaseFixture().InactivateRequest();
            var existingSubject = new SubjectEntity
            {
                SubjectId = 1,
                Description = "Description test"
            };

            A.CallTo(() => _SubjectRepository.GetAsync(existingSubject.SubjectId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(existingSubject));
            A.CallTo(() => _SubjectRepository.UpdateAsync(existingSubject, A<CancellationToken>.Ignored))
                .Returns(Task.CompletedTask);

            // Act
            var useCase = new DeleteSubjectUseCase(_SubjectRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Message.Should().Be(SubjectInactivateSuccessMessage);
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Should_NotSubject_When_SubjectDoesNotExist()
        {
            // Arrange
            var input = new DeleteSubjectUseCaseFixture().InactivateRequest();

            A.CallTo(() => _SubjectRepository.GetAsync(input.SubjectId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult<SubjectEntity>(null));

            // Act
            var useCase = new DeleteSubjectUseCase(_SubjectRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Message.Should().Be(SubjectNotExistsMessage);
            response.IsSuccess.Should().BeFalse();
            response.BusinessRuleViolation.Should().BeTrue();
        }

        [Fact]
        public async Task Should_HandleException_When_ExceptionThrown()
        {
            // Arrange
            var input = new DeleteSubjectUseCaseFixture().InactivateRequest();
            var existingSubject = new SubjectEntity
            {
                SubjectId = 1,
                Description = "Description test"
            };
         
            A.CallTo(() => _SubjectRepository.DeleteAsync(A<int>.Ignored, A<CancellationToken>.Ignored))
                .Throws(new Exception("Database update failed"));

            // Act
            var useCase = new DeleteSubjectUseCase(_SubjectRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ExceptionInactivateMessage);
        }
    }
}
