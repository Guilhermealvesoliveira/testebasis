using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Dtos.SaleTypes.Response
{
    public class GetSaleTypeResponse : BaseResponse<GetSaleTypeResponseData>
    {
    }
    public class GetSaleTypeResponseData
    {
        public int SaleTypeId { get; set; }
        public required string Description { get; set; }
    }
}
