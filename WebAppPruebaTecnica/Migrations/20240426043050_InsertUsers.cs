using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppPruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class InsertUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductViewModelId",
                table: "Providers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductViewModel", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductViewModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductViewModelId",
                value: null);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { 3, "sale2@mail.com", "Sale2", "123456789", 2 },
                    { 4, "sale3@mail.com", "Sale3", "123456789", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ProductViewModelId",
                table: "Providers",
                column: "ProductViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_ProductViewModel_ProductViewModelId",
                table: "Providers",
                column: "ProductViewModelId",
                principalTable: "ProductViewModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_ProductViewModel_ProductViewModelId",
                table: "Providers");

            migrationBuilder.DropTable(
                name: "ProductViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Providers_ProductViewModelId",
                table: "Providers");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "ProductViewModelId",
                table: "Providers");
        }
    }
}
