using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PROMHUB.Migrations
{
    /// <inheritdoc />
    public partial class AddProductListTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_Company_CompanyId",
                table: "ProductShop");

            migrationBuilder.DropIndex(
                name: "IX_ProductShop_CompanyId",
                table: "ProductShop");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ProductShop");

            migrationBuilder.CreateTable(
                name: "ProductList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductList_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductList_ProductId",
                table: "ProductList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductList_UserId",
                table: "ProductList",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductList");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "ProductShop",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_CompanyId",
                table: "ProductShop",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_Company_CompanyId",
                table: "ProductShop",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }
    }
}
