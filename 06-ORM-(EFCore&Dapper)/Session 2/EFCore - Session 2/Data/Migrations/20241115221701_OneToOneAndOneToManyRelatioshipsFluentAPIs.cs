using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore___Session_2.Data.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneAndOneToManyRelatioshipsFluentAPIs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deps_Employees_ManagerId",
                table: "Deps");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Deps_DepartmentDeptId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Deps_ManagerId",
                table: "Deps");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Deps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Deps_ManagerId",
                table: "Deps",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Deps_Employees_ManagerId",
                table: "Deps",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Code",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Deps_DepartmentDeptId",
                table: "Employees",
                column: "DepartmentDeptId",
                principalTable: "Deps",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deps_Employees_ManagerId",
                table: "Deps");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Deps_DepartmentDeptId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Deps_ManagerId",
                table: "Deps");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Deps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deps_ManagerId",
                table: "Deps",
                column: "ManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deps_Employees_ManagerId",
                table: "Deps",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Deps_DepartmentDeptId",
                table: "Employees",
                column: "DepartmentDeptId",
                principalTable: "Deps",
                principalColumn: "DeptId");
        }
    }
}
