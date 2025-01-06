using TesteBasisBook.Domain.Common;
namespace TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs
{
    public class GetSubjectOutput : BaseOutputModel<GetSubjectOutputData>
    {
    }
    public class GetSubjectOutputData
    {
        public int SubjectId { get; set; }
        public required string Description { get; set; }
    }
}
