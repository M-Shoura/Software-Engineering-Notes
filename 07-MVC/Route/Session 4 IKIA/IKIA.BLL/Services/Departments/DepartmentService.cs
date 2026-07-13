using IKIA.BLL.DTOs.Departments;
using IKIA.DAL.Models.Departments;
using IKIA.DAL.Presistence.Repositories.Departments;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IKIA.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        // Here we must talk to the repository .. so we will make this field and ask the CLR to provide the object in the constructor 

        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentToReturnDTO> GetAllDepartments()
        {
            // var departments = _departmentRepository.GetAll();
            // 
            // // Note that we return a custom model ... so we must use Manual mapping or use a package called "AutoMapper" to do the 
            // // mapping but it's recommended to use manual mapping in small and basic tasks as the package decreases the performance 
            // // or we can make an overloading for the casting operator (last session OOP) =>  
            // 
            // foreach(var department in departments)
            // {
            //     yield return new DepartmentToReturnDTO()
            //     {
            //         Id = department.Id,
            //         Name = department.Name,
            //         Code = department.Code,
            //         CreationDate = department.CreationDate,
            //         Description = department.Description
            //     };
            // }
            // 
            // // // or use the casting operator we implemented : 
            // // foreach (var department in departments)
            // // {
            // //     yield return (DepartmentToReturnDTO) department;
            // //     
            // // }

            // The previous code has a performance issue , GetAll in the repo gets all the column of department table , but we want
            // only some of them (as the DepartmentToReturnDTO) ... so we will add another function in the Repository : 

            var departments = _departmentRepository.GetAllAsIQueryable().Select(department => new DepartmentToReturnDTO()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,
            }).AsNoTracking().ToList();

            return departments;
        }

        public DepartmentDetailsToReturnDTO? GetDepartmentById(int departmentId)
        {
            var dept = _departmentRepository.Get(departmentId);
            if (dept is not null)
            {
                // or if (dept != null )
                // or if (dept is {})     ==> new .Net 8 feature , means that it's an object 
                return new DepartmentDetailsToReturnDTO()
                {
                    Id = dept.Id,
                    Name = dept.Name,
                    Code = dept.Code,
                    CreatedBy = dept.CreatedBy,
                    CreatedOn = dept.CreatedOn,
                    CreationDate = dept.CreationDate,
                    Description = dept.Description,
                    LastModifiedBy = dept.LastModifiedBy,
                    LastModifiedOn = dept.LastModifiedOn
                };
            }        
            
            return null;
        }

        public int CreateDepartment(CreatedDepartmentDTO departmentDTO)
        {
            // Here we can write any validations or business logic

            var department = new Department()
            {
                Name = departmentDTO.Name,
                Code = departmentDTO.Code,
                CreationDate = departmentDTO.CreationDate,
                Description = departmentDTO.Description,

                CreatedBy = 1,
                // CreatedOn = DateTime.UtcNow,            // has default value in the configurations and the migration 
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,   // we use UTCNow to make sure that we will have the same value in the DB for any country
                IsDeleted = false
            };

            return _departmentRepository.Add(department);
        }

        public int UpdateDepartment(UpdatedDepartmentDTO departmentDTO)
        {
            var department = new Department()
            {
                Id = departmentDTO.Id,
                Name = departmentDTO.Name,
                Code = departmentDTO.Code,
                Description = departmentDTO.Description,
                CreationDate = departmentDTO.CreationDate,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow
            };

            return _departmentRepository.Update(department);    
        }

        public bool DeleteDepartment(int departmentId)
        {
            var department = _departmentRepository.Get(departmentId);
            if (department is { })
                return _departmentRepository.Delete(department) > 0;

            return false;
        }
    }
}
