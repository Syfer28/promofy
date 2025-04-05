using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PROMHUB.Migrations
{
    /// <inheritdoc />
    public partial class DeleteProductController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProduct_ProductGets_ProductGetId",
                table: "CompanyProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProduct_ProductPostPuts_ProductPostPutId",
                table: "CompanyProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_ProductGets_ProductGetId",
                table: "ProductShop");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShop_ProductPostPuts_ProductPostPutId",
                table: "ProductShop");

            migrationBuilder.DropTable(
                name: "ProductGets");

            migrationBuilder.DropTable(
                name: "ProductPostPuts");

            migrationBuilder.DropIndex(
                name: "IX_ProductShop_ProductGetId",
                table: "ProductShop");

            migrationBuilder.DropIndex(
                name: "IX_ProductShop_ProductPostPutId",
                table: "ProductShop");

            migrationBuilder.DropIndex(
                name: "IX_CompanyProduct_ProductGetId",
                table: "CompanyProduct");

            migrationBuilder.DropIndex(
                name: "IX_CompanyProduct_ProductPostPutId",
                table: "CompanyProduct");

            migrationBuilder.DropColumn(
                name: "ProductGetId",
                table: "ProductShop");

            migrationBuilder.DropColumn(
                name: "ProductPostPutId",
                table: "ProductShop");

            migrationBuilder.DropColumn(
                name: "ProductGetId",
                table: "CompanyProduct");

            migrationBuilder.DropColumn(
                name: "ProductPostPutId",
                table: "CompanyProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductGetId",
                table: "ProductShop",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductPostPutId",
                table: "ProductShop",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductGetId",
                table: "CompanyProduct",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductPostPutId",
                table: "CompanyProduct",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductGets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    PhotoBlob = table.Column<byte[]>(type: "bytea", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPostPuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    PhotoBlob = table.Column<byte[]>(type: "bytea", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPostPuts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ProductGetId",
                table: "ProductShop",
                column: "ProductGetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ProductPostPutId",
                table: "ProductShop",
                column: "ProductPostPutId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProduct_ProductGetId",
                table: "CompanyProduct",
                column: "ProductGetId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProduct_ProductPostPutId",
                table: "CompanyProduct",
                column: "ProductPostPutId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProduct_ProductGets_ProductGetId",
                table: "CompanyProduct",
                column: "ProductGetId",
                principalTable: "ProductGets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProduct_ProductPostPuts_ProductPostPutId",
                table: "CompanyProduct",
                column: "ProductPostPutId",
                principalTable: "ProductPostPuts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_ProductGets_ProductGetId",
                table: "ProductShop",
                column: "ProductGetId",
                principalTable: "ProductGets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShop_ProductPostPuts_ProductPostPutId",
                table: "ProductShop",
                column: "ProductPostPutId",
                principalTable: "ProductPostPuts",
                principalColumn: "Id");
        }
    }
}
