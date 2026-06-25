using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore___Session_3.Migrations
{
    /// <inheritdoc />
    public partial class FirstOfAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deps",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    DeptName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false, computedColumnSql: "Cast(GETDATE() as Date)"),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deps", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DetailedAddress_BlockNumber = table.Column<int>(type: "int", nullable: false),
                    DetailedAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailedAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailedAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Employees_Deps_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Deps",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deps_ManagerId",
                table: "Deps",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deps_Employees_ManagerId",
                table: "Deps",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deps_Employees_ManagerId",
                table: "Deps");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Deps");
        }
    }
}
