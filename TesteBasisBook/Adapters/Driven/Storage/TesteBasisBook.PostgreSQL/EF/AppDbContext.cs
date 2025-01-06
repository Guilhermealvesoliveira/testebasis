using Microsoft.EntityFrameworkCore;
using TesteBasisBook.Domain.Entity;
namespace TesteBasisBook.PostgreSQL.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>()
                .HasMany(u => u.AuthorBooks)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.BookId);

            modelBuilder.Entity<Subject>()
     .HasMany(u => u.SubjectBooks)
     .WithOne(a => a.Subject)
     .HasForeignKey(a => a.SubjectId);

            modelBuilder.Entity<Author>()
       .HasMany(u => u.AuthorBooks)
       .WithOne(a => a.Author)
       .HasForeignKey(a => a.AuthorId);

            modelBuilder.Entity<SaleType>()
.HasMany(u => u.SaleTypeBookPrice)
.WithOne(a => a.SaleType)
.HasForeignKey(a => a.SaleTypeId);

            modelBuilder.Entity<SubjectBook>()
.HasKey(ab => new { ab.BookId, ab.SubjectId });

            modelBuilder.Entity<SubjectBook>()
                .HasOne(a => a.Book)
                .WithMany(u => u.SubjectBooks)
                .HasForeignKey(a => a.BookId);

            modelBuilder.Entity<SubjectBook>()
                .HasOne(ab => ab.Subject)
                .WithMany(a => a.SubjectBooks) // A relação com o Author
                .HasForeignKey(ab => ab.SubjectId);

            modelBuilder.Entity<AuthorBook>()
       .HasKey(ab => new { ab.BookId, ab.AuthorId }); // Definindo a chave primária composta

            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Book)
                .WithMany(b => b.AuthorBooks) // A relação com o Book
                .HasForeignKey(ab => ab.BookId);

            modelBuilder.Entity<AuthorBook>()
                .HasOne(ab => ab.Author)
                .WithMany(a => a.AuthorBooks) // A relação com o Author
                .HasForeignKey(ab => ab.AuthorId);


            modelBuilder.Entity<SaleTypeBookPrice>()
.HasKey(ab => new { ab.BookId, ab.SaleTypeId });

            modelBuilder.Entity<SaleTypeBookPrice>()
                .HasOne(a => a.Book)
                .WithMany(u => u.SaleTypeBookPrice)
                .HasForeignKey(a => a.BookId);

            modelBuilder.Entity<SaleTypeBookPrice>()
                .HasOne(ab => ab.SaleType)
                .WithMany(a => a.SaleTypeBookPrice) // A relação com o Author
                .HasForeignKey(ab => ab.SaleTypeId);
        }
        public DbSet<Book> Book { get; set; } = null!;
        public DbSet<AuthorBook> AuthorBook { get; set; } = null!;
        public DbSet<SubjectBook> SubjectBook { get; set; } = null!;
        public DbSet<Subject> Subject { get; set; } = null!;
        public DbSet<Author> Author { get; set; } = null!;
    }
}
