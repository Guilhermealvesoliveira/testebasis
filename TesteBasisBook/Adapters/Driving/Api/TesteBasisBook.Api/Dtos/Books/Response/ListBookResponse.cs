using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Dtos.Books.Response
{
    public class ListBookResponse : BaseResponse<ListBookResponseData>
    {
    }

    public class ListBookResponseData
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required string Publisher { get; set; }

        public required int Edition { get; set; }
        public required string PublicationYear { get; set; }
    }
}
