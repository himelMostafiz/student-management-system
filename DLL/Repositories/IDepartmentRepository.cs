using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IDepartmentRepository:IGenericCrudRepository<Department>
    {
        //Task<List<Department>> GetAll();
        //Task<Department> GetADepartment(string code);
        //Task<Department> GetADepartmentByName(string name);
        //Task<Department> Insert(Department aDepartment);
        //Task<Department> Update(String code, Department aDepartment);
        //Task<bool> Update(Department aDepartment);
        //Task<bool> Delete(Department aDepartment);
    }
}
