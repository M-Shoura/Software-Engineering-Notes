using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Order_Aggregate
{
    // Will not be mapped to a database table , mapped with Order table and gets the default values from the Actual address of the User
    public class Address
    {
        // The EFCore (When making migration) wants a accessible empty parameterless constructor for classes that will be mapped to table 
        // or classes used inside classed mapped to tables so we will make empty constructors for all the classes we've made in order module
        // These Ctors can be private also , to have only by the efcore when generating tables and forcing users to use the other ctors
        public Address()
        {

        }
        public Address(string firstName, string lastName, string street, string city, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            Country = country;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
