using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBasisBook.Domain.Application.UseCases.Subjects.Inputs
{
    public class UpdateSubjectInput
    {
        public int SubjectId { get; set; }
        public required string Description { get; set; }
    }
}
