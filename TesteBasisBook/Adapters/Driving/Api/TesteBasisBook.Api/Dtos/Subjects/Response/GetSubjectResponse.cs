using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Dtos.Subjects.Response
{
    public class GetSubjectResponse : BaseResponse<GetSubjectResponseData>
    {
    }
    public class GetSubjectResponseData
    {
        public int SubjectId { get; set; }
        public required string Description { get; set; }
    }
}
