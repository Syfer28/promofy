using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PROMHUB.Migrations
{
    /// <inheritdoc />
    public partial class Main3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Product",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.CreateTable(
                name: "ProductGets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    ProductDistributorId = table.Column<int>(type: "integer", nullable: false),
                    PhotoBlob = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGets_ProductDistributor_ProductDistributorId",
                        column: x => x.ProductDistributorId,
                        principalTable: "ProductDistributor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPostPuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    ProductDistributorId = table.Column<int>(type: "integer", nullable: false),
                    PhotoBlob = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPostPuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPostPuts_ProductDistributor_ProductDistributorId",
                        column: x => x.ProductDistributorId,
                        principalTable: "ProductDistributor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductGets_ProductDistributorId",
                table: "ProductGets",
                column: "ProductDistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPostPuts_ProductDistributorId",
                table: "ProductPostPuts",
                column: "ProductDistributorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductGets");

            migrationBuilder.DropTable(
                name: "ProductPostPuts");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Product",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
