using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBasisBook.Domain.Application.UseCases.SaleTypes.Inputs
{
    public class UpdateSaleTypeInput
    {
        public int SaleTypeId { get; set; }
        public required string Description { get; set; }
    }
}
