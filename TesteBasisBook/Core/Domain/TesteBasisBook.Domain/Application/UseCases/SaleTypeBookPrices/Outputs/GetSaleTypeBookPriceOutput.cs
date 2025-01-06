using System.ComponentModel.DataAnnotations.Schema;
using TesteBasisBook.Domain.Common;
namespace TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs
{
    public class GetSaleTypeBookPriceOutput : BaseOutputModel<GetSaleTypeBookPriceOutputData>
    {
    }
    public class GetSaleTypeBookPriceOutputData
    {
        public int SaleTypeId { get; set; }
        public int BookId { get; set; }
        public double Price { get; set; }
    }
}
