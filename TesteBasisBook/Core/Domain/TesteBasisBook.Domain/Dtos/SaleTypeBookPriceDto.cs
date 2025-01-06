
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBasisBook.Domain.Dtos
{
    public class SaleTypeBookPriceDto
    {
        public int BookId { get; set; }
        public int SaleTypeId { get; set; }
        public double Price { get; set; }
        public required string BookTitle { get; set; }
        public required string SaleType { get; set; }
    }
}
