using FakeItEasy;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using TesteBasisBook.Application.Test.UseCases.SubjectsManage.Subject.Fixtures;
using SubjectEntity = TesteBasisBook.Domain.Entity.Subject;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.Application.Services.Subjects;

namespace TesteBasisBook.Application.UseCases.SubjectsManage.Subject
{
    public class CreateSubjectUseCaseTest
    {
        private readonly ISubjectRepository _SubjectRepository;
        private readonly ILogger<CreateSubjectUseCase> _logger;

        private const string SubjectInsertSuccessMessage = "Subject saved successfully";
        private const string SubjectExistsMessage = "Subject already";
        private const string ExceptionCreationMessage = "Failed to retrieve Subject.";

        public CreateSubjectUseCaseTest()
        {
            _SubjectRepository = A.Fake<ISubjectRepository>();
            _logger = A.Fake<ILogger<CreateSubjectUseCase>>();
        }

        [Fact]
        public async Task Should_CreateSubject_When_Success()
        {
            //Arrange
           var input = new CreateSubjectUseCaseFixture().CreateRequest();
            A.CallTo(() => _SubjectRepository.InsertAsync(A<SubjectEntity>.Ignored, A<CancellationToken>.Ignored)).Returns(1);
            A.CallTo(() => _SubjectRepository.GetSubjectByDescriptionAsync(A<string>.Ignored, A<CancellationToken>.Ignored)).Returns(null as SubjectEntity);


            //Act
            var useCase = new CreateSubjectUseCase(_SubjectRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.Message.Should().Be(SubjectInsertSuccessMessage);
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Should_NotCreateSubject_When_SubjectExists()
        {
            //Arrange
            var input = new CreateSubjectUseCaseFixture().CreateRequest();
            var mockSubject = new SubjectEntity
            {
                Description = input.Description,
                SubjectId = 1
            };
            A.CallTo(() => _SubjectRepository.GetSubjectByDescriptionAsync(A<string>.Ignored, A<CancellationToken>.Ignored)).Returns(mockSubject);


            //Act
            var useCase = new CreateSubjectUseCase(_SubjectRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.Message.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.BusinessRuleViolation.Should().BeTrue();
            response.Message.Should().Contain(SubjectExistsMessage);
        }

        

        [Fact]
        public async Task Should_HandleException_When_ExceptionThrown()
        {
            //Arrange
           var input = new CreateSubjectUseCaseFixture().CreateRequest();

            A.CallTo(() => _SubjectRepository.InsertAsync(A<SubjectEntity>.Ignored, A<CancellationToken>.Ignored)).Throws(new Exception());
            A.CallTo(() => _SubjectRepository.GetSubjectByDescriptionAsync(A<string>.Ignored, A<CancellationToken>.Ignored)).Returns(null as SubjectEntity);

            //Act
            var useCase = new CreateSubjectUseCase(_SubjectRepository, _logger);
            var response = await useCase.ExecuteAsync(input, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeFalse();
            response.Message.Should().Be(ExceptionCreationMessage);
        }
    }
}