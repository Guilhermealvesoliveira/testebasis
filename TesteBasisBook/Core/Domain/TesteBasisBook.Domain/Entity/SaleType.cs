using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBasisBook.Domain.Entity
{
    [Table("TipoVenda", Schema = "teste_basis")]

    public class SaleType
    {
        [Column("CodTv")]
        [Key]
        public int SaleTypeId { get; set; }
        [Column("Descricao", TypeName = "varchar(40)")]
        public required string Description { get; set; }

        [Description("ignore")]
        public ICollection<SaleTypeBookPrice> SaleTypeBookPrice { get; set; } = default!;
    }
}
