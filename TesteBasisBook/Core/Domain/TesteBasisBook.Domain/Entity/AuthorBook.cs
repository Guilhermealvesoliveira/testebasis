using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBasisBook.Domain.Entity
{
    [Table("Livro_Autor", Schema = "teste_basis")]
    public class AuthorBook
    {
        [Column("CodAu")]
        public int AuthorId { get; set; }
        [Column("CodL")]
        public int BookId { get;set; }
        [Description("ignore")]
        public Book Book { get; set; }
        [Description("ignore")]
        public Author Author { get; set; }
    }
}
