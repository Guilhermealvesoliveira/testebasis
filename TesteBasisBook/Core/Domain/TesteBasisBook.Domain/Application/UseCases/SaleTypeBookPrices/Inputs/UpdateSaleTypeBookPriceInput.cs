using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Inputs
{
    public class UpdateSaleTypeBookPriceInput
    {
        public int SaleTypeId { get; set; }
        public int BookId { get; set; }
        public double Price { get; set; }
    }
}
