using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Core_Intro.Migrations
{
    public partial class UseFluentAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentNumber",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentNumber",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentNumber",
                table: "Employees",
                column: "DepartmentNumber",
                principalTable: "Departments",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentNumber",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentNumber",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentNumber",
                table: "Employees",
                column: "DepartmentNumber",
                principalTable: "Departments",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
