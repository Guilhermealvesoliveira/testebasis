using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using TesteBasisBook.Application.Services.Subjects;
using TesteBasisBook.Application.Test.UseCases.SubjectsManage.Subject.Fixtures;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using SubjectEntity = TesteBasisBook.Domain.Entity.Subject;

namespace TesteBasisBook.Application.UseCases.SubjectsManage.Subject
{
    public class UpdateSubjectUseCaseTest
    {
        private readonly ISubjectRepository _SubjectRepository;
        private readonly ILogger<UpdateSubjectUseCase> _logger;

        private const string SubjectUpdateSuccessMessage = "Subject updated successfully";
        private const string SubjectNotExistsMessage = "Subject not found";
        private const string ExceptionUpdateMessage = "Failed to retrieve entity.";
        public UpdateSubjectUseCaseTest()
        {
            _SubjectRepository = A.Fake<ISubjectRepository>();
            _logger = A.Fake<ILogger<UpdateSubjectUseCase>>();
        }
        [Fact]
        public async Task Should_UpdateSubject_When_Success()
        {
            // Arrange
            var input = new UpdateSubjectUseCaseFixture().UpdateRequest();
            var existingSubject = new SubjectEntity
            {
                SubjectId = input.SubjectId,
                Description = input.Description,
            };

            A.CallTo(() => _SubjectRepository.GetAsync(existingSubject.SubjectId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(existingSubject));
            A.CallTo(() => _SubjectRepository.UpdateAsync(A<SubjectEntity>.Ignored, A<CancellationToken>.Ignored))
                .Returns(Task.CompletedTask);

            // Act
            var useCase = new UpdateSubjectUseCase(_SubjectRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Message.Should().Be(SubjectUpdateSuccessMessage);
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Should_NotUpdateSubject_When_SubjectDoesNotExist()
        {
            // Arrange
            var input = new UpdateSubjectUseCaseFixture().UpdateRequest();
            A.CallTo(() => _SubjectRepository.GetAsync(input.SubjectId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(null as SubjectEntity));

            // Act
            var useCase = new UpdateSubjectUseCase(_SubjectRepository, _logger);
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
            var input = new UpdateSubjectUseCaseFixture().UpdateRequest();
            var existingSubject = new SubjectEntity
            {
                SubjectId = input.SubjectId,
                Description = "test",
            };
            A.CallTo(() => _SubjectRepository.GetAsync(input.SubjectId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(existingSubject));

            A.CallTo(() => _SubjectRepository.UpdateAsync(A<SubjectEntity>.Ignored, A<CancellationToken>.Ignored))
                .Throws(new Exception("Database update failed"));
            // Act
            var useCase = new UpdateSubjectUseCase(_SubjectRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);
            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ExceptionUpdateMessage);
        }
    }
}
