using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Response
{
    public class ListSaleTypeBookPriceResponse : BaseResponse<ListSaleTypeBookPriceResponseData>
    {
    }

    public class ListSaleTypeBookPriceResponseData
    {
        public int BookId { get; set; }
        public int SaleTypeId { get; set; }
        public double Price { get; set; }
        public required string BookTitle { get; set; }
        public required string SaleType { get; set; }
    }
}
