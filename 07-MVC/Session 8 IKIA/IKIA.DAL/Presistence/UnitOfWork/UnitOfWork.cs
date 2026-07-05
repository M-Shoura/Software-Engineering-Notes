using IKIA.DAL.Presistence.Data;
using IKIA.DAL.Presistence.Repositories.Departments;
using IKIA.DAL.Presistence.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Presistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbcontext _dbcontext;

        public IEmployeeRepository EmployeeRepository { get { return new EmployeeRepository(_dbcontext); } /*set;*/ }
        public IDepartmentRepository DepartmentRepository { get { return new DepartmentRepository(_dbcontext); } /*set;*/ }

        public UnitOfWork(ApplicationDbcontext dbcontext)       // ASKing the CLR here to provide an object from "ApplicationDbContext"
        {
            _dbcontext = dbcontext;
            // EmployeeRepository = new EmployeeRepository(_dbcontext);
            // DepartmentRepository = new DepartmentRepository(_dbcontext);

            // As we initialize them like this with "new" keyword , then we don't ask the CLR to provide us with an object , then we can 
            // remove them from the services container in the Program class 


            // bad implementation ! if a service wantes to interact with the database , then it will use the UnitOfWork , the unit of work 
            // in the Ctor makes an object from each and every repository !! maybe we want to use only one repo so why making objects from 
            // all of them ??? 

            // Now we will comment the initializing of repository properties inside the ctor and we will make the properties as readonly 
            // (get without set) , and in the get we will give a new object from the wanted Repo


            // The current imp is not good also and have a problem , what will happed when requesting an object from the repo through the
            // unit of work class multiple times ? we will create more than one object from the repo !! this problem will be solved in 
            // APIs , we will discuss a new implementation for solving this problem (using Dictionary and HashMap for storing the objects
            // created from the repositories we have) 

        }
        public async Task<int> CompleteAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }


        public  async ValueTask DisposeAsync()
        {
           await _dbcontext.DisposeAsync();
        }
    }
}
