using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TesteBasisBook.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class create_initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "teste_basis");

            migrationBuilder.CreateTable(
                name: "Assunto",
                schema: "teste_basis",
                columns: table => new
                {
                    CodAs = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assunto", x => x.CodAs);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                schema: "teste_basis",
                columns: table => new
                {
                    CodAu = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_autor", x => x.CodAu);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                schema: "teste_basis",
                columns: table => new
                {
                    CodL = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "varchar(40)", nullable: false),
                    Editora = table.Column<string>(type: "varchar(40)", nullable: false),
                    Edicao = table.Column<int>(type: "integer", nullable: false),
                    AnoPublicacao = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_livro", x => x.CodL);
                });

            migrationBuilder.CreateTable(
                name: "Livro_Assunto",
                schema: "teste_basis",
                columns: table => new
                {
                    CodAs = table.Column<int>(type: "integer", nullable: false),
                    CodL = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_livro_assunto", x => new { x.CodL, x.CodAs });
                    table.ForeignKey(
                        name: "fk_livro_assunto_assunto_codas",
                        column: x => x.CodAs,
                        principalSchema: "teste_basis",
                        principalTable: "Assunto",
                        principalColumn: "CodAs",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_livro_assunto_livro_codl",
                        column: x => x.CodL,
                        principalSchema: "teste_basis",
                        principalTable: "Livro",
                        principalColumn: "CodL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livro_Autor",
                schema: "teste_basis",
                columns: table => new
                {
                    CodAu = table.Column<int>(type: "integer", nullable: false),
                    CodL = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_livro_autor", x => new { x.CodL, x.CodAu });
                    table.ForeignKey(
                        name: "fk_livro_autor_autor_codau",
                        column: x => x.CodAu,
                        principalSchema: "teste_basis",
                        principalTable: "Autor",
                        principalColumn: "CodAu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_livro_autor_livro_codl",
                        column: x => x.CodL,
                        principalSchema: "teste_basis",
                        principalTable: "Livro",
                        principalColumn: "CodL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_livro_assunto_codas",
                schema: "teste_basis",
                table: "Livro_Assunto",
                column: "CodAs");

            migrationBuilder.CreateIndex(
                name: "ix_livro_autor_codau",
                schema: "teste_basis",
                table: "Livro_Autor",
                column: "CodAu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro_Assunto",
                schema: "teste_basis");

            migrationBuilder.DropTable(
                name: "Livro_Autor",
                schema: "teste_basis");

            migrationBuilder.DropTable(
                name: "Assunto",
                schema: "teste_basis");

            migrationBuilder.DropTable(
                name: "Autor",
                schema: "teste_basis");

            migrationBuilder.DropTable(
                name: "Livro",
                schema: "teste_basis");
        }
    }
}
