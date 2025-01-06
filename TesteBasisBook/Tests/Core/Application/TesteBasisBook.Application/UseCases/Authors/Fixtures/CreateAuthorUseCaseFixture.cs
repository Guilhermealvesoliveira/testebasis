using AutoFixture;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;
namespace TesteBasisBook.Application.Test.UseCases.AuthorsManage.Author.Fixtures
{
    public class CreateAuthorUseCaseFixture
    {
        private readonly Fixture _fixture;
        public CreateAuthorUseCaseFixture()
        {
            _fixture = new Fixture();
        }

        public  CreateAuthorInput CreateRequest()
        {
            return _fixture.Create<CreateAuthorInput>();
        }

        public CreateAuthorOutput CreateResponse()
        {
            return _fixture.Create<CreateAuthorOutput>();
        }
    }
}
