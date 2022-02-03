using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1263087.Migrations
{
    public partial class AltColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "EmployeeVM",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(maxLength: 25, nullable: false),
                    ContactAddress = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    ConfirmEmail = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVM_DepartmentID",
                table: "EmployeeVM",
                column: "DepartmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeVM");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
