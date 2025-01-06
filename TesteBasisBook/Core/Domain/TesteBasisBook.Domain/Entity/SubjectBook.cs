using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBasisBook.Domain.Entity
{
    [Table("Livro_Assunto", Schema = "teste_basis")]
    public class SubjectBook
    {
        [Column("CodAs")]
        public int SubjectId { get; set; }
        [Column("CodL")]
        public int BookId { get; set; }
        [Description("ignore")]
        public  Book Book { get; set; } 
        [Description("ignore")]
        public  Subject Subject { get; set; }

    }
}
