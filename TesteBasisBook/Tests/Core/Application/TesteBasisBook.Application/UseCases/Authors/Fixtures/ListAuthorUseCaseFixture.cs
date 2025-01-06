using AutoFixture;
using TesteBasisBook.Domain.Application.UseCases.Authors.Inputs;
using TesteBasisBook.Domain.Application.UseCases.Authors.Outputs;

namespace TesteBasisBook.Application.Test.UseCases.AuthorsManage.Author.Fixtures
{
    public class ListAuthorUseCaseFixture
    {
        private readonly Fixture _fixture;
        public ListAuthorUseCaseFixture()
        {
            _fixture = new Fixture();
        }
        public ListAuthorInput CreateRequest()
        {
            return _fixture.Create<ListAuthorInput>();
        }
        public ListAuthorOutput CreateResponse(bool withAuthors = true)
        {
            var output = _fixture.Create<ListAuthorOutput>();

            if (withAuthors)
            {
                output.Data = new List<ListAuthorOutputData>
                {
                    _fixture.Create<ListAuthorOutputData>(),
                     _fixture.Create<ListAuthorOutputData>(),
                };
            }
            else
            {
                output.Data = new List<ListAuthorOutputData>();
            }

            return output;
        }
    }
}
