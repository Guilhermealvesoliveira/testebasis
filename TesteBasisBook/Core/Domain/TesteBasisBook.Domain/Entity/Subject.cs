using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBasisBook.Domain.Entity
{
    [Table("Assunto", Schema = "teste_basis")]

    public class Subject
    {
        [Column("CodAs")]
        [Key]
        public int SubjectId { get; set; }
        [Column("Descricao", TypeName = "varchar(20)")]
        public required string Description { get; set; }

        [Description("ignore")]
        public ICollection<SubjectBook> SubjectBooks { get; set; } = default!;
    }
}
