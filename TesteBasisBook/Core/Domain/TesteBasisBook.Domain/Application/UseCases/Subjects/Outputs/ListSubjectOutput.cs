using TesteBasisBook.Domain.Common;
namespace TesteBasisBook.Domain.Application.UseCases.Subjects.Outputs
{
    public class ListSubjectOutput : BaseOutputModel<List<ListSubjectOutputData>>
    {
    }
    public class ListSubjectOutputData
    {
        public int SubjectId { get; set; }
        public required string Description { get; set; }
    }
}
