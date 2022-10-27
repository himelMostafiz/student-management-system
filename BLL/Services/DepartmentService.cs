using BLL.Request_Validation;
using DLL.Models;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Exceptions;

namespace BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
       // private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWorkRepository _unitOfWork;
        public DepartmentService(IUnitOfWorkRepository unitOfWork)
        {
            // _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Department> GetAllDepartmentQueryable()
        {
            return _unitOfWork.DepartmentRepository.QueryAll();
        }
        public async Task<List<Department>> GetAllDepartmentAsync()
        {
            //var departmentList = await _departmentRepository.GetAllAsync();
            var departmentList = await _unitOfWork.DepartmentRepository.GetAllAsync();
            if (departmentList.Count == 0)
                throw new ApplicationValidationException("No departments found.");

            return departmentList;
        }
        public async Task<Department> GetADepartmentAsync(string code)
        {
            var department = await _unitOfWork.DepartmentRepository.FindSingleEntityAsync(x=>x.Code == code);
            if (department == null)
                throw new ApplicationValidationException("Department not found.");

            return department;
        }

        public async Task<Department> AddDepartmentAsync(DepartmentInserRequestValidationModel departmentRequestValidation)
        {
            Department aDepartment = new Department();
            aDepartment.Code = departmentRequestValidation.Code;
            aDepartment.Name = departmentRequestValidation.Name;

            await _unitOfWork.DepartmentRepository.CreateAsync(aDepartment);

            if (await _unitOfWork.DepartmentRepository.SaveCompletedAsync())
            {
                return aDepartment;
            }

            throw new ApplicationException("Some error occurs to insert the department data.");

            //return await _departmentInterface.Insert(aDepartment);
        }

        public async Task<Department> UpdateDepartmentAsync(string code, DepartmentInserRequestValidationModel departmentRequestValidation)
        {
            var department = await _unitOfWork.DepartmentRepository.FindSingleEntityAsync(x=>x.Code==code);

            if (department == null)
            {
                throw new ApplicationValidationException("Department not found.");
            }

            if (!string.IsNullOrWhiteSpace(departmentRequestValidation.Code))
            {
                var codeAlreadyExist = await _unitOfWork.DepartmentRepository.FindSingleEntityAsync(x => x.Code == departmentRequestValidation.Code);
                if(codeAlreadyExist != null)
                {
                    throw new ApplicationValidationException("Department code already exist.");
                }
                department.Code = departmentRequestValidation.Code;
            }

            if (!string.IsNullOrWhiteSpace(departmentRequestValidation.Name))
            {
                var nameAlreadyExist = await _unitOfWork.DepartmentRepository.FindSingleEntityAsync(x => x.Name == departmentRequestValidation.Name);
                if (nameAlreadyExist != null)
                {
                    throw new ApplicationValidationException("Department name already exist.");
                }
                department.Name = departmentRequestValidation.Name;
            }

            _unitOfWork.DepartmentRepository.Update(department);

            if (await _unitOfWork.DepartmentRepository.SaveCompletedAsync())
            {
                return department;
            }

            throw new ApplicationValidationException("Some problem for updating data.");

            //return await _departmentInterface.Update(code, aDepartment);
        }

        public async Task<Department> DeleteDepartmentAsync(string code)
        {
           var adepartment = await _unitOfWork.DepartmentRepository.FindSingleEntityAsync(x=>x.Code==code);
            if (adepartment == null)
            {
                throw new ApplicationValidationException("Department not found.");
            }

            _unitOfWork.DepartmentRepository.Delete(adepartment);
            
            if (await _unitOfWork.DepartmentRepository.SaveCompletedAsync())
            {
                return adepartment;
            }
            throw new ApplicationValidationException("Some problem for deleting data.");
        }

        public async Task<bool> IsDepartmentCodeAlreadyExist(string code)
        {
            var isDepartmentCodeExist = false;

            if (!string.IsNullOrEmpty(code))
            {
                var dept = await _unitOfWork.DepartmentRepository.FindSingleEntityAsync(d=>d.Code ==code);
                if (dept != null)
                    isDepartmentCodeExist = true;
            }
            return isDepartmentCodeExist;
        }

        public async Task<bool> IsDepartmentNameAlreadyExist(string name)
        {
            var isDepartmentNameeExist = false;

            if (!string.IsNullOrEmpty(name))
            {
                var dept = await _unitOfWork.DepartmentRepository.FindSingleEntityAsync(d => d.Name == name);
                if (dept != null)
                    isDepartmentNameeExist = true;
            }
            return isDepartmentNameeExist;
        }
    }
}
