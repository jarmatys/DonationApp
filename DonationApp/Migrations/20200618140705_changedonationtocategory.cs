using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationApp.Migrations
{
    public partial class changedonationtocategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryDonationModel_Categories_CategoryModelId",
                table: "CategoryDonationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryDonationModel_Donations_DonationId",
                table: "CategoryDonationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryDonationModel_Instituties_InstitutionId",
                table: "CategoryDonationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryDonationModel",
                table: "CategoryDonationModel");

            migrationBuilder.DropIndex(
                name: "IX_CategoryDonationModel_CategoryModelId",
                table: "CategoryDonationModel");

            migrationBuilder.DropIndex(
                name: "IX_CategoryDonationModel_InstitutionId",
                table: "CategoryDonationModel");

            migrationBuilder.DropColumn(
                name: "CategoryModelId",
                table: "CategoryDonationModel");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "CategoryDonationModel");

            migrationBuilder.RenameTable(
                name: "CategoryDonationModel",
                newName: "CategoryDonation");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryDonationModel_DonationId",
                table: "CategoryDonation",
                newName: "IX_CategoryDonation_DonationId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CategoryDonation",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryDonation",
                table: "CategoryDonation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDonation_CategoryId",
                table: "CategoryDonation",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryDonation_Categories_CategoryId",
                table: "CategoryDonation",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryDonation_Donations_DonationId",
                table: "CategoryDonation",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryDonation_Categories_CategoryId",
                table: "CategoryDonation");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryDonation_Donations_DonationId",
                table: "CategoryDonation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryDonation",
                table: "CategoryDonation");

            migrationBuilder.DropIndex(
                name: "IX_CategoryDonation_CategoryId",
                table: "CategoryDonation");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CategoryDonation");

            migrationBuilder.RenameTable(
                name: "CategoryDonation",
                newName: "CategoryDonationModel");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryDonation_DonationId",
                table: "CategoryDonationModel",
                newName: "IX_CategoryDonationModel_DonationId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryModelId",
                table: "CategoryDonationModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "CategoryDonationModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryDonationModel",
                table: "CategoryDonationModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDonationModel_CategoryModelId",
                table: "CategoryDonationModel",
                column: "CategoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDonationModel_InstitutionId",
                table: "CategoryDonationModel",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryDonationModel_Categories_CategoryModelId",
                table: "CategoryDonationModel",
                column: "CategoryModelId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryDonationModel_Donations_DonationId",
                table: "CategoryDonationModel",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryDonationModel_Instituties_InstitutionId",
                table: "CategoryDonationModel",
                column: "InstitutionId",
                principalTable: "Instituties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
