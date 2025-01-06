using TesteBasisBook.Domain.Common;
namespace TesteBasisBook.Domain.Application.UseCases.Books.Outputs
{
    public class ListBookOutput : BaseOutputModel<List<ListBookOutputData>>
    {
    }
    public class ListBookOutputData
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required string Publisher { get; set; }

        public required int Edition { get; set; }
        public required string PublicationYear { get; set; }
    }
}
