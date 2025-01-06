using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Dtos.Authors.Response
{
    public class GetAuthorResponse : BaseResponse<GetAuthorResponseData>
    {
    }
    public class GetAuthorResponseData
    {
        public int AuthorId { get; set; }
        public required string Name { get; set; }
    }
}
