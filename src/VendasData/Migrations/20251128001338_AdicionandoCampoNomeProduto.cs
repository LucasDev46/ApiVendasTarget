using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasData.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCampoNomeProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "varchar(30)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Produtos");
        }
    }
}
