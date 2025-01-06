using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBasisBook.Domain.Application.UseCases.Authors.Inputs
{
    public class UpdateAuthorInput
    {
        public int AuthorId { get; set; }
        public required string Name { get; set; }
    }
}
