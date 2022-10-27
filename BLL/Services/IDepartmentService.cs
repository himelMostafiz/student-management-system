using BLL.Request_Validation;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   public interface IDepartmentService
    {
        IQueryable<Department> GetAllDepartmentQueryable();
        Task<List<Department>> GetAllDepartmentAsync();
        Task<Department> GetADepartmentAsync(string code);
        Task<Department> AddDepartmentAsync(DepartmentInserRequestValidationModel departmentRequestValidation);
        Task<Department> UpdateDepartmentAsync(String code, DepartmentInserRequestValidationModel departmentRequestValidation);
        Task<Department> DeleteDepartmentAsync(string code);
        Task<bool> IsDepartmentCodeAlreadyExist(string code);
        Task<bool> IsDepartmentNameAlreadyExist(string name);
    }
}
