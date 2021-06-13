using Microsoft.EntityFrameworkCore.Migrations;

namespace Apz_backend.Migrations
{
    public partial class FinalAdjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Medications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Medications_UserId",
                table: "Medications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medications_Users_UserId",
                table: "Medications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medications_Users_UserId",
                table: "Medications");

            migrationBuilder.DropIndex(
                name: "IX_Medications_UserId",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Medications");
        }
    }
}
