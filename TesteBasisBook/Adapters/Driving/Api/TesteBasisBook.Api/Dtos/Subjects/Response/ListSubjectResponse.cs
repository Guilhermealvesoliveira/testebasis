using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Dtos.Subjects.Response
{
    public class ListSubjectResponse : BaseResponse<ListSubjectResponseData>
    {
    }

    public class ListSubjectResponseData
    {
        public int SubjectId { get; set; }
        public required string Description { get; set; }
    }
}
