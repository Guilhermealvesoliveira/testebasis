﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TesteBasisBook.PostgreSQL.EF;

#nullable disable

namespace TesteBasisBook.PostgreSQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250103212137_create_initial")]
    partial class create_initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TesteBasisBook.Domain.Entity.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("CodAu");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Nome");

                    b.HasKey("AuthorId")
                        .HasName("pk_autor");

                    b.ToTable("Autor", "teste_basis");
                });

            modelBuilder.Entity("TesteBasisBook.Domain.Entity.AuthorBook", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("CodL");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("CodAu");

                    b.HasKey("BookId", "AuthorId")
                        .HasName("pk_livro_autor");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("ix_livro_autor_codau");

                    b.ToTable("Livro_Autor", "teste_basis");
                });

            modelBuilder.Entity("TesteBasisBook.Domain.Entity.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("CodL");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookId"));

                    b.Property<int>("Edition")
                        .HasColumnType("integer")
                        .HasColumnName("Edicao");

                    b.Property<string>("PublicationYear")
                        .IsRequired()
                        .HasColumnType("varchar(4)")
                        .HasColumnName("AnoPublicacao");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Editora");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Titulo");

                    b.HasKey("BookId")
                        .HasName("pk_livro");

                    b.ToTable("Livro", "teste_basis");
                });

            modelBuilder.Entity("TesteBasisBook.Domain.Entity.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("CodAs");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Descricao");

                    b.HasKey("SubjectId")
                        .HasName("pk_assunto");

                    b.ToTable("Assunto", "teste_basis");
                });

            modelBuilder.Entity("TesteBasisBook.Domain.Entity.SubjectBook", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("CodL");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer")
                        .HasColumnName("CodAs");

                    b.HasKey("BookId", "SubjectId")
                        .HasName("pk_livro_assunto");

                    b.HasIndex("SubjectId")
                        .HasDatabaseName("ix_livro_assunto_codas");

                    b.ToTable("Livro_Assunto", "teste_basis");
                });

            modelBuilder.Entity("TesteBasisBook.Domain.Entity.AuthorBook", b =>
                {
                    b.HasOne("TesteBasisBook.Domain.Entity.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_livro_autor_autor_codau");

                    b.HasOne("TesteBasisBook.Domain.Entity.Book", "Book")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_livro_autor_livro_codl");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("TesteBasisBook.Domain.Entity.SubjectBook", b =>
                {
                    b.HasOne("TesteBasisBook.Domain.Entity.Book", "Book")
                        .WithMany("SubjectBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_livro_assunto_livro_codl");

                    b.HasOne("TesteBasisBook.Domain.Entity.Subject", "Subject")
                        .WithMany("SubjectBooks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_livro_assunto_assunto_codas");

                    b.Navigation("Book");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("TesteBasisBook.Domain.Entity.Author", b =>
                {
                    b.Navigation("AuthorBooks");
                });

            modelBuilder.Entity("TesteBasisBook.Domain.Entity.Book", b =>
                {
                    b.Navigation("AuthorBooks");

                    b.Navigation("SubjectBooks");
                });

            modelBuilder.Entity("TesteBasisBook.Domain.Entity.Subject", b =>
                {
                    b.Navigation("SubjectBooks");
                });
#pragma warning restore 612, 618
        }
    }
}