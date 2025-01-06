using TesteBasisBook.Domain.Common;
namespace TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs
{
    public class GetSaleTypeOutput : BaseOutputModel<GetSaleTypeOutputData>
    {
    }
    public class GetSaleTypeOutputData
    {
        public int SaleTypeId { get; set; }
        public required string Description { get; set; }
    }
}
