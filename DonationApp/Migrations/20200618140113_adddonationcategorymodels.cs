using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationApp.Migrations
{
    public partial class adddonationcategorymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Donations_DonationModelId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_DonationModelId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DonationModelId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "CategoryDonationModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationId = table.Column<int>(nullable: false),
                    InstitutionId = table.Column<int>(nullable: false),
                    CategoryModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDonationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryDonationModel_Categories_CategoryModelId",
                        column: x => x.CategoryModelId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryDonationModel_Donations_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryDonationModel_Instituties_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Instituties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDonationModel_CategoryModelId",
                table: "CategoryDonationModel",
                column: "CategoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDonationModel_DonationId",
                table: "CategoryDonationModel",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDonationModel_InstitutionId",
                table: "CategoryDonationModel",
                column: "InstitutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryDonationModel");

            migrationBuilder.AddColumn<int>(
                name: "DonationModelId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DonationModelId",
                table: "Categories",
                column: "DonationModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Donations_DonationModelId",
                table: "Categories",
                column: "DonationModelId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
