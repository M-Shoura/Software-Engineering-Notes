using EFCore___Session_3.Data.Models;
using System.Text.Json;

namespace EFCore___Session_3.Data.DataSeed
{
	internal static class CompanyDbContextSeed
	{
		public static void Seed(CompanyDbContext dbContext)
		{

			// From string Json to a type ==> Deserialization
			// From Type to a Json ==> Serialization

			if (!dbContext.Employees.Any())
			{
				var EmployeesData = File.ReadAllText("../../../Data/DataSeed/Employees.json");
				var Employees = JsonSerializer.Deserialize<List<Employee>>(EmployeesData);
				if (Employees?.Count > 0)
				{
					foreach (var Emp in Employees)
					{
						dbContext.Employees.Add(Emp);
					}
				}
			}
			if (!dbContext.Departments.Any())
			{
				var DepartmentsData = File.ReadAllText("../../../Data/DataSeed/Departments.json");
				var Departments = JsonSerializer.Deserialize<List<Department>>(DepartmentsData);

				if (Departments?.Count > 0)
				{
					foreach (var dep in Departments)
					{
						dbContext.Departments.Add(dep);
					}
				}
			}

			dbContext.SaveChanges();
		}
	}
}
