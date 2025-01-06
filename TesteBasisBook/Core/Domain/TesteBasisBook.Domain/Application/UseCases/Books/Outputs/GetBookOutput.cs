using TesteBasisBook.Domain.Common;
namespace TesteBasisBook.Domain.Application.UseCases.Books.Outputs
{
    public class GetBookOutput : BaseOutputModel<GetBookOutputData>
    {
    }
    public class GetBookOutputData
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required string Publisher { get; set; }

        public required int Edition { get; set; }
        public required string PublicationYear { get; set; }
        public IEnumerable<int> SubjectsId { get; set; }
        public IEnumerable<int> AuthorsId { get; set; }
    }
}
