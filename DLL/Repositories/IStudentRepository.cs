using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IStudentRepository : IGenericCrudRepository<Student>
    {
        //Task<List<Student>> GetAllAsync();
        //Task<Student> GetAStudentAsync(string email);
        //Task<Student> InsertAsync(Student astudent);
        //Task<Student> UpdateAsync(string email, Student astudent);
        //Task<Student> DeleteAsync(string email);

    }
}
