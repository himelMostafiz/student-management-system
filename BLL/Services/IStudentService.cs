using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DLL.Models;

namespace BLL.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetAStudentAsync(string email);
        Task<Student> AddStudentAsync(Student astudent);
        Task<Student> UpdateStudentAsync(string email, Student astudent);
        Task<Student> DeleteStudentAsync(string email);
        Task<bool> GetStudentById(int studentId);
        Task<bool> IsStudentEmailAlreadyExist(string email);
    }
}
