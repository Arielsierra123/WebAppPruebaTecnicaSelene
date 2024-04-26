using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppPruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class AddNitColumnProviderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nit",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nit",
                table: "Providers");
        }
    }
}
