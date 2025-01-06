using System.ComponentModel.DataAnnotations;

namespace TesteBasisBook.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public required Guid Id { get; set; }

    }
}
