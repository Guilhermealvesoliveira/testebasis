using AutoFixture;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;
namespace TesteBasisBook.Application.Test.UseCases.SubjectsManage.Subject.Fixtures
{
    public class CreateSubjectUseCaseFixture
    {
        private readonly Fixture _fixture;
        public CreateSubjectUseCaseFixture()
        {
            _fixture = new Fixture();
        }

        public  CreateSubjectInput CreateRequest()
        {
            return _fixture.Create<CreateSubjectInput>();
        }

        public CreateSubjectOutput CreateResponse()
        {
            return _fixture.Create<CreateSubjectOutput>();
        }
    }
}
