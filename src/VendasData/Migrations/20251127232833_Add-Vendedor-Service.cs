using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasData.Migrations
{
    /// <inheritdoc />
    public partial class AddVendedorService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Vendedores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Vendedores");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Produtos");
        }
    }
}
