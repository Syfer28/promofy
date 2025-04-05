using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PROMHUB.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGets_ProductDistributor_ProductDistributorId",
                table: "ProductGets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPostPuts_ProductDistributor_ProductDistributorId",
                table: "ProductPostPuts");

            migrationBuilder.DropTable(
                name: "ProductDistributor");

            migrationBuilder.DropTable(
                name: "Distributor");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "CompanyInfo");

            migrationBuilder.RenameColumn(
                name: "ProductDistributorId",
                table: "ProductPostPuts",
                newName: "ProductShopId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPostPuts_ProductDistributorId",
                table: "ProductPostPuts",
                newName: "IX_ProductPostPuts_ProductShopId");

            migrationBuilder.RenameColumn(
                name: "ProductDistributorId",
                table: "ProductGets",
                newName: "ProductShopId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGets_ProductDistributorId",
                table: "ProductGets",
                newName: "IX_ProductGets_ProductShopId");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Company",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CompanyProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProduct_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    AddressString = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Longitude = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Latitude = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductShop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShopId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductShop_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShop_Shop_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProduct_CompanyId",
                table: "CompanyProduct",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProduct_ProductId",
                table: "CompanyProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ProductId",
                table: "ProductShop",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ShopId",
                table: "ProductShop",
                column: "ShopId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shop_CompanyId",
                table: "Shop",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGets_ProductShop_ProductShopId",
                table: "ProductGets",
                column: "ProductShopId",
                principalTable: "ProductShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPostPuts_ProductShop_ProductShopId",
                table: "ProductPostPuts",
                column: "ProductShopId",
                principalTable: "ProductShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGets_ProductShop_ProductShopId",
                table: "ProductGets");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPostPuts_ProductShop_ProductShopId",
                table: "ProductPostPuts");

            migrationBuilder.DropTable(
                name: "CompanyProduct");

            migrationBuilder.DropTable(
                name: "ProductShop");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "ProductShopId",
                table: "ProductPostPuts",
                newName: "ProductDistributorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPostPuts_ProductShopId",
                table: "ProductPostPuts",
                newName: "IX_ProductPostPuts_ProductDistributorId");

            migrationBuilder.RenameColumn(
                name: "ProductShopId",
                table: "ProductGets",
                newName: "ProductDistributorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGets_ProductShopId",
                table: "ProductGets",
                newName: "IX_ProductGets_ProductDistributorId");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "CompanyInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Distributor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    AddressString = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Longitude = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distributor_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDistributor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DistributorId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDistributor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDistributor_Distributor_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDistributor_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Distributor_CompanyId",
                table: "Distributor",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDistributor_DistributorId",
                table: "ProductDistributor",
                column: "DistributorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDistributor_ProductId",
                table: "ProductDistributor",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGets_ProductDistributor_ProductDistributorId",
                table: "ProductGets",
                column: "ProductDistributorId",
                principalTable: "ProductDistributor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPostPuts_ProductDistributor_ProductDistributorId",
                table: "ProductPostPuts",
                column: "ProductDistributorId",
                principalTable: "ProductDistributor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
