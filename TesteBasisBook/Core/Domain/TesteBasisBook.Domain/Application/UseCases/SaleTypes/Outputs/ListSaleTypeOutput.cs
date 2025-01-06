using TesteBasisBook.Domain.Common;
namespace TesteBasisBook.Domain.Application.UseCases.SaleTypes.Outputs
{
    public class ListSaleTypeOutput : BaseOutputModel<List<ListSaleTypeOutputData>>
    {
    }
    public class ListSaleTypeOutputData
    {
        public int SaleTypeId { get; set; }
        public required string Description { get; set; }
    }
}
