using AutoFixture;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;
namespace TesteBasisBook.Application.Test.UseCases.SubjectsManage.Subject.Fixtures
{
    public class UpdateSubjectUseCaseFixture
    {
        private readonly Fixture _fixture;
        public UpdateSubjectUseCaseFixture()
        {
            _fixture = new Fixture();
        }
        public UpdateSubjectInput UpdateRequest()
        {
            return _fixture.Create<UpdateSubjectInput>();
        }
        public UpdateSubjectOutput UpdateResponse()
        {
            return _fixture.Create<UpdateSubjectOutput>();
        }
    }
}

