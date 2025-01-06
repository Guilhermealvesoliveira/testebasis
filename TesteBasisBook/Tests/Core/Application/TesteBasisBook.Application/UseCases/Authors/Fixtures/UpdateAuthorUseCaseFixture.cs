using AutoFixture;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;
namespace TesteBasisBook.Application.Test.UseCases.AuthorsManage.Author.Fixtures
{
    public class UpdateAuthorUseCaseFixture
    {
        private readonly Fixture _fixture;
        public UpdateAuthorUseCaseFixture()
        {
            _fixture = new Fixture();
        }
        public UpdateAuthorInput UpdateRequest()
        {
            return _fixture.Create<UpdateAuthorInput>();
        }
        public UpdateAuthorOutput UpdateResponse()
        {
            return _fixture.Create<UpdateAuthorOutput>();
        }
    }
}

