using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolConsole.Migrations
{
    /// <inheritdoc />
    public partial class DropTablesToMakeItEasy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullTimeStudent");

            migrationBuilder.DropTable(
                name: "WalkInStudent");

            migrationBuilder.DropSequence(
                name: "PersonSequence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "PersonSequence");

            migrationBuilder.CreateTable(
                name: "FullTimeStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PersonSequence]"),
                    IsEnroller = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EnrollmentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Grade = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullTimeStudent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalkInStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PersonSequence]"),
                    IsEnroller = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkInStudent", x => x.Id);
                });
        }
    }
}
