using Microsoft.EntityFrameworkCore.Migrations;

namespace _1263087.Migrations
{
    public partial class AddColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Staffs_StaffId",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Experiences",
                newName: "StaffID");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_StaffId",
                table: "Experiences",
                newName: "IX_Experiences_StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Staffs_StaffID",
                table: "Experiences",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Staffs_StaffID",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "StaffID",
                table: "Experiences",
                newName: "StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Experiences_StaffID",
                table: "Experiences",
                newName: "IX_Experiences_StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Staffs_StaffId",
                table: "Experiences",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
