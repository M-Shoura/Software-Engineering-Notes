using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_1.Data.Models
{
	internal class Project
	{
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateOnly CreationDate { get; set; }
		// Note : DateOnly and TimeOnly Datatypes were introduced in .net 5.0 , but the EfCore 5.0 we couldn't use them .. in .net 6.0 and 7.0 to use 
		//        DateOnly and TimeOnly Datatype we must install a package to use them .. in .net 8.0 we can use them without any installations or errors !
	}
}
