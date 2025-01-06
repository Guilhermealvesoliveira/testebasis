using TesteBasisBook.Domain.Common;
namespace TesteBasisBook.Domain.Application.UseCases.Authors.Outputs
{
    public class ListAuthorOutput : BaseOutputModel<List<ListAuthorOutputData>>
    {
    }
    public class ListAuthorOutputData
    {
        public int AuthorId { get; set; }
        public required string Name { get; set; }
    }
}
