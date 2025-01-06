using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Response
{
    public class GetSaleTypeBookPriceResponse : BaseResponse<GetSaleTypeBookPriceResponseData>
    {
    }
    public class GetSaleTypeBookPriceResponseData
    {
        public int BookId { get; set; }
        public int SaleTypeId { get; set; }
        public double Price { get; set; }

    }
}
