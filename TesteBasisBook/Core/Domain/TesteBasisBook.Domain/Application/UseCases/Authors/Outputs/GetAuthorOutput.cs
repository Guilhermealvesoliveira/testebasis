using TesteBasisBook.Domain.Common;
namespace TesteBasisBook.Domain.Application.UseCases.Authors.Outputs
{
    public class GetAuthorOutput : BaseOutputModel<GetAuthorOutputData>
    {
    }
    public class GetAuthorOutputData
    {
        public int AuthorId { get; set; }
        public required string Name { get; set; }
    }
}
