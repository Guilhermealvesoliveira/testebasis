namespace TesteBasisBook.Domain.Application.UseCases.Books.Inputs
{
    public class CreateBookInput
    {
        public required string Title { get; set; }
        public required string Publisher { get; set; }

        public required int Edition { get; set; }
        public required string PublicationYear { get; set; }
        public List<int> SubjectsId { get; set; }
        public List<int> AuthorsId { get; set; }



    }
}
