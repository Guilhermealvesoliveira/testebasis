using TesteBasisBook.Domain.Common;

namespace TesteBasisBook.Api.Dtos.SaleTypes.Response
{
    public class ListSaleTypeResponse : BaseResponse<ListSaleTypeResponseData>
    {
    }

    public class ListSaleTypeResponseData
    {
        public int SaleTypeId { get; set; }
        public required string Description { get; set; }
    }
}
