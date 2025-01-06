using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using TesteBasisBook.Application.Services.Subjects;
using TesteBasisBook.Application.Test.UseCases.SubjectsManage.Subject.Fixtures;
using TesteBasisBook.Application.Test.UseCases.UsersManage.User.Fixtures;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using SubjectEntity = TesteBasisBook.Domain.Entity.Subject;

namespace TesteBasisBook.Application.UseCases.SubjectsManage.Subject
{
    public class GetSubjectUseCaseTest
    {
        private readonly ISubjectRepository _SubjectRepository;
        private readonly ILogger<GetSubjectUseCase> _logger;
        private const string SubjectNotExistsMessage = "Subject not found";
        private const string ExceptionInactivateMessage = "Failed to retrieve entity.";
         private const string SubjectGetSuccessMessage = "Subject Get successfully";

        
        public GetSubjectUseCaseTest()
        {
            _SubjectRepository = A.Fake<ISubjectRepository>();
            _logger = A.Fake<ILogger<GetSubjectUseCase>>();
        }

        [Fact]
        public async Task Should_GetSubject_When_Success()
        {
            // Arrange
            var input = new GetSubjectUseCaseFixture().GetRequest();

            var existingSubject = new SubjectEntity
            {
                SubjectId = input.SubjectId,
                Description = "Descríption test"
            };


            A.CallTo(() => _SubjectRepository.GetAsync(input.SubjectId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult(existingSubject));

            var useCase = new GetSubjectUseCase(_SubjectRepository, _logger);

            // Act
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.Message.Should().Be(SubjectGetSuccessMessage);
            response.Data.Should().NotBeNull();
            response.Data.SubjectId.Should().Be(existingSubject.SubjectId);
            response.Data.Description.Should().Be(existingSubject.Description);

        }

        [Fact]
        public async Task Should_NotGetSubject_when_SubjectDoesNotExist_in_database()
        {
            // Arrange
            var input = new GetSubjectUseCaseFixture().GetRequest();

            A.CallTo(() => _SubjectRepository.GetAsync(input.SubjectId, A<CancellationToken>.Ignored))
                .Returns(Task.FromResult<SubjectEntity>(null));

            // Act
            var useCase = new GetSubjectUseCase(_SubjectRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(SubjectNotExistsMessage);
            response.BusinessRuleViolation.Should().BeTrue();
        }
        [Fact]
        public async Task Should_HandleException_When_ExceptionThrown()
        {
            // Arrange
            var input = new GetSubjectUseCaseFixture().GetRequest();
            var existingSubject = new SubjectEntity
            {
                SubjectId = 1,
                Description = "Description test"
            };

            A.CallTo(() => _SubjectRepository.GetAsync(A<int>.Ignored, A<CancellationToken>.Ignored))
                .Throws(new Exception("Database get failed"));

            // Act
            var useCase = new GetSubjectUseCase(_SubjectRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ExceptionInactivateMessage);
        }
    }
}
