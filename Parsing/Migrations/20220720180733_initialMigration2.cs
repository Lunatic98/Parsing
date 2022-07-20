using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parsing.Migrations
{
    public partial class initialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SellerName = table.Column<string>(type: "text", nullable: true),
                    SellerInn = table.Column<string>(type: "text", nullable: true),
                    BuyerName = table.Column<string>(type: "text", nullable: true),
                    BuyerInn = table.Column<string>(type: "text", nullable: true),
                    WoodVolumeBuyer = table.Column<double>(type: "double precision", nullable: true),
                    WoodVolumeSeller = table.Column<double>(type: "double precision", nullable: true),
                    DealDate = table.Column<string>(type: "text", nullable: true),
                    DealNumber = table.Column<string>(type: "text", nullable: true),
                    Typename = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deals");
        }
    }
}
