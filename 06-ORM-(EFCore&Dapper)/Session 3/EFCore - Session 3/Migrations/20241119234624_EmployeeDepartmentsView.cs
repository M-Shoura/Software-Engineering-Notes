using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore___Session_3.Migrations
{
	/// <inheritdoc />
	public partial class EmployeeDepartmentsView : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"create view EmployeeDepartmentsView
									with encryption , schemabinding
									As
									select E.Code 'EmployeeCode' , E.Name 'EmployeeName' , D.DeptId 'DepartmentId' , D.DeptName 'DepartmentName'
									from dbo.Employees E left outer join dbo.Deps D
									on E.DepartmentId = D.DeptId");

		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("drop view EmployeeDepartmentsView");
		}
	}
}
