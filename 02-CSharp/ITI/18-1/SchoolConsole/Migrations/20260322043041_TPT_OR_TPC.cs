using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolConsole.Migrations
{
    /// <inheritdoc />
    public partial class TPT_OR_TPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsEnroller = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FullTimeStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<byte>(type: "tinyint", nullable: false),
                    EnrollmentDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullTimeStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullTimeStudent_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalkInStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkInStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalkInStudent_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullTimeStudent");

            migrationBuilder.DropTable(
                name: "WalkInStudent");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
