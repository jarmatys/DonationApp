using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationApp.Migrations
{
    public partial class addonationandinstitiutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DonationModelId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Instituties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    InstitutionId = table.Column<int>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PickUpDate = table.Column<DateTime>(nullable: false),
                    PickUpTime = table.Column<DateTime>(nullable: false),
                    PickUpComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Instituties_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Instituties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DonationModelId",
                table: "Categories",
                column: "DonationModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_InstitutionId",
                table: "Donations",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Donations_DonationModelId",
                table: "Categories",
                column: "DonationModelId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Donations_DonationModelId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Instituties");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DonationModelId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DonationModelId",
                table: "Categories");
        }
    }
}
