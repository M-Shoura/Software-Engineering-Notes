using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore___Session_2.Data.Migrations
{
    /// <inheritdoc />
    public partial class DateOnlyAndDateCasting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreationDate",
                table: "Deps",
                type: "date",
                nullable: false,
                computedColumnSql: "Cast(GETDATE() as Date)",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldComputedColumnSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreationDate",
                table: "Deps",
                type: "date",
                nullable: false,
                computedColumnSql: "GETDATE()",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldComputedColumnSql: "Cast(GETDATE() as Date)");
        }
    }
}
