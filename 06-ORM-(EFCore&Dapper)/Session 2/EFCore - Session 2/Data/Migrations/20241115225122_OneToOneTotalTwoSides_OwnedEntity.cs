using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore___Session_2.Data.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneTotalTwoSides_OwnedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetailedAddress_BlockNumber",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DetailedAddress_City",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailedAddress_Country",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailedAddress_Street",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailedAddress_BlockNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DetailedAddress_City",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DetailedAddress_Country",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DetailedAddress_Street",
                table: "Employees");
        }
    }
}
