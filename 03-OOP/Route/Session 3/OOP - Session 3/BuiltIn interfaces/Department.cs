using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_3.BuiltIn_interfaces
{
	internal class Department : ICloneable
	{
        public int Id { get; set; }
		public string? Name { get; set; }

		public object Clone()
		{
			return new Department() { 
				Id = this.Id, 
				Name = this.Name 
			};
		}
		public override string ToString()
		{
			return $"Department Id: {Id}, Department Name: {Name}";
		}
	}
}
