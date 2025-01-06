
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TesteBasisBook.Domain.Entity
{
    [Table("Livro", Schema = "teste_basis")]
    public class Book
    {
        [Column("CodL")]
        [Key]
        public int BookId { get; set; } = default;

        [Column("Titulo", TypeName = "varchar(40)")]
        public required string Title { get; set; }
        
        [Column("Editora", TypeName = "varchar(40)")]
        public required string Publisher { get; set; }
        [Column("Edicao")]
        public required int Edition { get; set; } = default;
        [Column("AnoPublicacao", TypeName = "varchar(4)")]
        public required string PublicationYear { get; set; }

        [Description("ignore")]
        public ICollection<AuthorBook> AuthorBooks { get; set; } = default!;

        [Description("ignore")]
        public ICollection<SubjectBook> SubjectBooks { get; set; } = default!;

        [Description("ignore")]
        public ICollection<SaleTypeBookPrice> SaleTypeBookPrice { get; set; } = default!;
    }
}
