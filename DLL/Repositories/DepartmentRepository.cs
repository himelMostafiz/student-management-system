using DLL.DBContext;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class DepartmentRepository :GenericCrudRepository<Department> ,IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }
        public async Task<Department> GetADepartment(string code)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d=> d.Code==code);
            return department;
        }
        public async Task<Department> Insert(Department aDepartment)
        {
            await _context.Departments.AddAsync(aDepartment);
            var isInserted = await _context.SaveChangesAsync();
            return aDepartment;
        }
        public async Task<Department> Update(string code, Department dept)
        {
            var aDepartment = await _context.Departments.FirstOrDefaultAsync(d=>d.Code == code);
            if (aDepartment.Code == dept.Code)
            {
                aDepartment.Name = dept.Name;
                 _context.Departments.Update(aDepartment);
                var isUpdate = await _context.SaveChangesAsync();
            }

            return dept;
        }

        public async Task<bool> Update(Department adepartment)
        {
            var isUpdated = false;
            _context.Departments.Update(adepartment);
            if (await _context.SaveChangesAsync() > 0)
                isUpdated = true;

            return isUpdated;
        }
        public async Task<bool> Delete(Department aDepartment)
        {
            var isDelated = false;
             _context.Departments.Remove(aDepartment);
            if (await _context.SaveChangesAsync() > 0)
            {
                isDelated = true;
            }
           
            return isDelated;
        }
        public async Task<Department> GetADepartmentByName(string name)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.Name == name);
            return department;
        }
    }
}
