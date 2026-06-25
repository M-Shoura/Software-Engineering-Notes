using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_2.Data.Models
{
	internal class Department
	{
        #region Properties
        
        public int DeptId { get; set; }
        public string Name { get; set; }
        public string CreationPlace { get; set; }
        public DateOnly CreationDate { get; set; }
        // - We cannot use DateOnly / TimeOnly in .net 5 and before ... 
        // - to use DateOnly / TimeOnly in .net 6 , .net 7 we must install package
        //   "ErikEJ.EntityFrameworkCore.SqlServer.DateOnlyTimeOnly" (search with "DateOnly" in NuGet Packages) & Edit the connection string to be :
        //   optionsBuilder.UseSqlServer("Server = . ; Database = CompanyNasr02 ; Trusted_Connection = true ; Encrypt = true ;
        //                                                            TrustServerCertificate = true" , options=>options.UseDateOnlyTimeOnly());
        //   To help EFCore 6 & 7 to know the datatype that will be mapped in the database table for "dataOnly" and "TimeOnly" properties in C# code 
        // - to use DateOnly / TimeOnly in .net 8 it's not important to install packages 

        #endregion

        // Now we will start making the reltionships : 

        // First Relationship :

        // Navigational Property [Many]
        [InverseProperty(nameof(Employee.Department))]
		public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        // We develop against interfaces , not concrete classes .. so it's not (List , array , ... ) . so it must be IEnumerable , but there is a class
        // that inherits from IEnumerable called "ICollection" that has all the functionalities provided by the IEnumerable interface + some other 
        // functions .... Also if we worked with database first approach the generated file by the EFCore will use ICollection not IEnumerable in 
        // [Many] side relationship ... Also Add , Clear , Remove will not affect the data in the database because the navigational property is not 
        // an actual column in the database , it's used only for holding the data after retrieving it from the database  

        // We must initialize the property of navigational property to retrieve the values when we want , and used HashSet because it's better that list 

        // if we commented the property here and kept it in the other side "One Side" , then by convention it will be knows as a 1 to many relationship 

        // Second Relationship (one to one -> employee manage department)
        [InverseProperty(nameof(Employee.ManagedDepartment))]
        public Employee? Manager { get; set; }

        [ForeignKey(nameof(Department.Manager))]
        public int? ManagerId { get; set; }
    }
}
