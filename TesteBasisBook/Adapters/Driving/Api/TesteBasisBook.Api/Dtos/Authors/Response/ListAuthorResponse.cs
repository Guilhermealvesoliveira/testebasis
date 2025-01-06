using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Dtos.Authors.Response
{
    public class ListAuthorResponse : BaseResponse<ListAuthorResponseData>
    {
    }

    public class ListAuthorResponseData
    {
        public int AuthorId { get; set; }
        public required string Name { get; set; }
    }
}
