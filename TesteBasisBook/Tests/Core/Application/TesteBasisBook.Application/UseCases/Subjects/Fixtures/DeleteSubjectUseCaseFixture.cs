using AutoFixture;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs;

namespace TesteBasisBook.Application.Test.UseCases.UsersManage.User.Fixtures
{
    public class DeleteSubjectUseCaseFixture
    {
        private readonly Fixture _fixture;
        public DeleteSubjectUseCaseFixture()
        {
            _fixture = new Fixture();
        }
        public DeleteSubjectInput InactivateRequest()
        {
            return _fixture.Create<DeleteSubjectInput>();
        }
        public DeleteSubjectOutput InactivateResponse()
        {
            return _fixture.Create<DeleteSubjectOutput>();
        }
    }
}
