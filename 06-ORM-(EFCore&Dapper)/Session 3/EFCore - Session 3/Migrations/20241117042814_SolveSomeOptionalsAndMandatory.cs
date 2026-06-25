using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore___Session_3.Migrations
{
    /// <inheritdoc />
    public partial class SolveSomeOptionalsAndMandatory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Deps_DepartmentId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DetailedAddress_BlockNumber",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Deps_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Deps",
                principalColumn: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Deps_DepartmentId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DetailedAddress_BlockNumber",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Deps_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Deps",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
