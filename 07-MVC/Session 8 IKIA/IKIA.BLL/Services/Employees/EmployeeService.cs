using IKIA.BLL.Common.Services.Attachments;
using IKIA.BLL.DTOs.Employees;
using IKIA.DAL.Models.Employees;
using IKIA.DAL.Presistence.Repositories.Employees;
using IKIA.DAL.Presistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.BLL.Services.Employees
{ 
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttachmentService _attachmentService;

        public EmployeeService(IUnitOfWork unitOfWork , IAttachmentService attachmentService)
        {
            _unitOfWork = unitOfWork;
            _attachmentService = attachmentService;
        }
        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync(string search)
        {
            return await _unitOfWork.EmployeeRepository
                .GetAllAsIQueryable()
                .Where(e=> !e.IsDeleted  &&  (string.IsNullOrEmpty(search) || e.Name.ToLower().Contains(search.ToLower()) ))
                .Include(e=>e.Department)
                .Select(e => new EmployeeDTO()
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Email = e.Email,
                IsActive = e.IsActive,
                Salary = e.Salary,
                EmployeeType = e.EmployeeType.ToString(),
                Gender = e.Gender.ToString(),
                Department = e.Department.Name,
                Image = e.Image
            }).ToListAsync();
        }
        public async Task<EmployeeDetailsDTO?> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetAsync(employeeId);

            if (employee == null)
                return null;
            return new EmployeeDetailsDTO()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                EmployeeType = employee.EmployeeType,
                Gender = employee.Gender,
                Address = employee.Address,
                HiringDate = employee.HiringDate,
                PhoneNumber = employee.PhoneNumber,
                Department = employee.Department?.Name??"",
                DepartmentId = employee.DepartmentId,
                Image = employee.Image
            };
        }
        public async Task<int> CreateEmployeeAsync(CreateEmployeeDTO employee)
        {
            var emp = new Employee()
            {
                Name = employee.Name,
                EmployeeType = employee.EmployeeType,
                Gender = employee.Gender,
                Email = employee.Email,
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                Age = employee.Age,
                Address = employee.Address,
                HiringDate = employee.HiringDate,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                DepartmentId = employee.DepartmentId,
            };

            if (employee.Image != null)
                emp.Image = await _attachmentService.UploadAsync(employee.Image, "images");

            _unitOfWork.EmployeeRepository.Add(emp);
            return await _unitOfWork.CompleteAsync();
        }
        public async Task<int> UpdateEmployeeAsync(UpdateEmployeeDTO employee)
        {
            var emp = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                EmployeeType = employee.EmployeeType,
                Gender = employee.Gender,
                Email = employee.Email,
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                Age = employee.Age,
                Address = employee.Address,
                HiringDate = employee.HiringDate,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                DepartmentId = employee.DepartmentId,
            };

            if (employee.Image != null)
                emp.Image = await _attachmentService.UploadAsync(employee.Image, "images");

            _unitOfWork.EmployeeRepository.Update(emp);
            return await _unitOfWork.CompleteAsync();
        }
        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            // var emp = _unitOfWork.EmployeeRepository.Get(employeeId);
            // if (emp is { })
            //     _unitOfWork.EmployeeRepository.Delete(emp);
            // 
            // return _unitOfWork.Complete() > 0;


            // Note : This is the problem that we talked about in the Ctor of class "UnitOfWork" , we requested multiple objects from the 
            //        Employee Repo here so this is not right and we must solve this problem (later discussed in APIs , but now we will
            //        solve the problem with bad way -> Storing the object of Repo in a variable and then using it .. )

            var UOF = _unitOfWork.EmployeeRepository;

            var emp = await UOF.GetAsync(employeeId);
            if (emp is { })
            {
                _attachmentService.Delete(emp.Image);
                UOF.Delete(emp);
            }

            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}