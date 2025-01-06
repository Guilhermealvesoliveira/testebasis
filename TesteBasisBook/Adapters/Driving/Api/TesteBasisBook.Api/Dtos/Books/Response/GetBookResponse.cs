using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Dtos.Books.Response
{
    public class GetBookResponse : BaseResponse<GetBookResponseData>
    {
    }
    public class GetBookResponseData
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
