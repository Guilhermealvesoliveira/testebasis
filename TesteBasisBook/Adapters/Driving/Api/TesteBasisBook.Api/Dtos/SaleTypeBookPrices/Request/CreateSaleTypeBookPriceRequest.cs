namespace TesteBasisBook.Api.Dtos.SaleTypeBookPrices.Request
{
    public class CreateSaleTypeBookPriceRequest
    {
        public int SaleTypeId { get; set; }
        public int BookId { get; set; }
        public double Price { get; set; }
    }
}
