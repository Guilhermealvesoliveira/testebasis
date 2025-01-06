using AutoFixture;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Application.Test.UseCases.SubjectsManage.Subject.Fixtures
{
    public class GetSubjectUseCaseFixture
    {
        private readonly Fixture _fixture;
        public GetSubjectUseCaseFixture()
        {
            _fixture = new Fixture();
        }
        public GetSubjectInput GetRequest()
        {
            return _fixture.Create<GetSubjectInput>();
        }
        public GetSubjectOutput GetResponse()
        {
            return _fixture.Create<GetSubjectOutput>();
        }
    }
}
