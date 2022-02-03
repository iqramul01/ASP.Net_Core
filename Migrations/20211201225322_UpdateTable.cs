using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1263087.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffVMStaffID",
                table: "Experiences",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StaffVM",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(maxLength: 25, nullable: false),
                    ContactAddress = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    ConfirmEmail = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffVM", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_StaffVM_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_StaffVMStaffID",
                table: "Experiences",
                column: "StaffVMStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffVM_DepartmentID",
                table: "StaffVM",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_StaffVM_StaffVMStaffID",
                table: "Experiences",
                column: "StaffVMStaffID",
                principalTable: "StaffVM",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_StaffVM_StaffVMStaffID",
                table: "Experiences");

            migrationBuilder.DropTable(
                name: "StaffVM");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_StaffVMStaffID",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "StaffVMStaffID",
                table: "Experiences");
        }
    }
}
