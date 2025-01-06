using TesteBasisBook.Domain.Common;
namespace TesteBasisBook.Domain.Application.UseCases.SaleTypeBookPrices.Outputs
{
    public class ListSaleTypeBookPriceOutput : BaseOutputModel<List<ListSaleTypeBookPriceOutputData>>
    {
    }
    public class ListSaleTypeBookPriceOutputData
    {
        public int SaleTypeId { get; set; }
        public int BookId { get; set; }
        public double Price { get; set; }
        public required string BookTitle { get; set; }
        public required string SaleType { get; set; }
    }
}
