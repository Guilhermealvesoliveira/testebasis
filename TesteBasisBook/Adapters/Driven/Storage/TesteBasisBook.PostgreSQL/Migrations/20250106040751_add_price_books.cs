using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TesteBasisBook.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class add_price_books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoVenda",
                schema: "teste_basis",
                columns: table => new
                {
                    CodTv = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipovenda", x => x.CodTv);
                });

            migrationBuilder.CreateTable(
                name: "Livro_TipoVenda_Preco",
                schema: "teste_basis",
                columns: table => new
                {
                    CodTv = table.Column<int>(type: "integer", nullable: false),
                    CodL = table.Column<int>(type: "integer", nullable: false),
                    Preco = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_livro_tipovenda_preco", x => new { x.CodL, x.CodTv });
                    table.ForeignKey(
                        name: "fk_livro_tipovenda_preco_livro_codl",
                        column: x => x.CodL,
                        principalSchema: "teste_basis",
                        principalTable: "Livro",
                        principalColumn: "CodL",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_livro_tipovenda_preco_tipovenda_codtv",
                        column: x => x.CodTv,
                        principalSchema: "teste_basis",
                        principalTable: "TipoVenda",
                        principalColumn: "CodTv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_livro_tipovenda_preco_codtv",
                schema: "teste_basis",
                table: "Livro_TipoVenda_Preco",
                column: "CodTv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro_TipoVenda_Preco",
                schema: "teste_basis");

            migrationBuilder.DropTable(
                name: "TipoVenda",
                schema: "teste_basis");
        }
    }
}
