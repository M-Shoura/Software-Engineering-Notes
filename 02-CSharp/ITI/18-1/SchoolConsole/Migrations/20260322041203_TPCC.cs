using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolConsole.Migrations
{
    /// <inheritdoc />
    public partial class TPCC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EnrollmentDate",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "WalkInStudent");

            migrationBuilder.CreateSequence(
                name: "PersonSequence");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "WalkInStudent",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WalkInStudent");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WalkInStudent",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [PersonSequence]"
                );

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalkInStudent",
                table: "WalkInStudent",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FullTimeStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [PersonSequence]"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsEnroller = table.Column<byte>(type: "tinyint", nullable: false),
                    Grade = table.Column<byte>(type: "tinyint", nullable: false),
                    EnrollmentDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullTimeStudent", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullTimeStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalkInStudent",
                table: "WalkInStudent");

            migrationBuilder.DropSequence(
                name: "PersonSequence");

            migrationBuilder.RenameTable(
                name: "WalkInStudent",
                newName: "People");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "People",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "People",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [PersonSequence]")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EnrollmentDate",
                table: "People",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Grade",
                table: "People",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");
        }
    }
}
