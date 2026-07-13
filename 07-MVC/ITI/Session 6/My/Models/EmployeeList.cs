namespace My.Models
{
    public class EmployeeList
    {
        public static List<Employee> Employees = new List<Employee>()
        {
            new Employee(){ID = 1, Name = "Mahmoud", Age=40},
            new Employee(){ID = 2, Name = "Ahmed",   Age=50},
            new Employee(){ID = 3, Name = "Shoura",  Age=60}
        };
    }
}
