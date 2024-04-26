using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppPruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsSaleProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_ProviderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProvderId",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxValue",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Providers_ProviderId",
                table: "Products",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Providers_ProviderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TaxValue",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Sales");

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProvderId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Providers_ProviderId",
                table: "Products",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id");
        }
    }
}
