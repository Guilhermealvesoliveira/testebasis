using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBasisBook.Domain.Entity
{
    [Table("Livro_TipoVenda_Preco", Schema = "teste_basis")]

    public class SaleTypeBookPrice
    {
        [Column("CodTv")]
        public int SaleTypeId { get; set; }
        [Column("CodL")]
        public int BookId { get; set; }
        [Column("Preco")]
        public double Price { get; set; }
        [Description("ignore")]
        public Book Book { get; set; }
        [Description("ignore")]
        public SaleType SaleType { get; set; }
    }
}
