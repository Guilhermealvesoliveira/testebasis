using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBasisBook.Domain.Entity
{
    [Table("Autor", Schema = "teste_basis")]
    public class Author
    {

        [Column("CodAu")]
        [Key]
        public int AuthorId { get; set; } = default;
        [Column("Nome", TypeName = "varchar(40)")]
        public required string Name { get; set; }

        [Description("ignore")]
        public ICollection<AuthorBook> AuthorBooks { get; set; } = default!;

    }
}
 