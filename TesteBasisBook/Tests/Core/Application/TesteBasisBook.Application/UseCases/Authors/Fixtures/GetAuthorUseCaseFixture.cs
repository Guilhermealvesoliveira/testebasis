using AutoFixture;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;

namespace TesteBasisBook.Application.Test.UseCases.AuthorsManage.Author.Fixtures
{
    public class GetAuthorUseCaseFixture
    {
        private readonly Fixture _fixture;
        public GetAuthorUseCaseFixture()
        {
            _fixture = new Fixture();
        }
        public GetAuthorInput GetRequest()
        {
            return _fixture.Create<GetAuthorInput>();
        }
        public GetAuthorOutput GetResponse()
        {
            return _fixture.Create<GetAuthorOutput>();
        }
    }
}
