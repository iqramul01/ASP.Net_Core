using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1263087.Migrations
{
    public partial class FinalUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    //name: "FK_Experiences_StaffVM_StaffVMStaffID",
            //    //table: "Experiences");

            //migrationBuilder.DropTable(
            //    name: "EmployeeVM");

            //migrationBuilder.DropTable(
            //    name: "StaffVM");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_StaffVMStaffID",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "StaffVMStaffID",
                table: "Experiences");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffVMStaffID",
                table: "Experiences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeVM",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfirmEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVM", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_EmployeeVM_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffVM",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfirmEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
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
                name: "IX_EmployeeVM_DepartmentID",
                table: "EmployeeVM",
                column: "DepartmentID");

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
    }
}
