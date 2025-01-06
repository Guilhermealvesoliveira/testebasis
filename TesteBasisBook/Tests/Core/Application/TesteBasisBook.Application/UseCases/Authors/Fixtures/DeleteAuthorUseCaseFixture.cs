using AutoFixture;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;

namespace TesteBasisBook.Application.Test.UseCases.UsersManage.User.Fixtures
{
    public class DeleteAuthorUseCaseFixture
    {
        private readonly Fixture _fixture;
        public DeleteAuthorUseCaseFixture()
        {
            _fixture = new Fixture();
        }
        public DeleteAuthorInput InactivateRequest()
        {
            return _fixture.Create<DeleteAuthorInput>();
        }
        public DeleteAuthorOutput InactivateResponse()
        {
            return _fixture.Create<DeleteAuthorOutput>();
        }
    }
}
