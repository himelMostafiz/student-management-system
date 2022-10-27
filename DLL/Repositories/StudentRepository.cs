using DLL.DBContext;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class StudentRepository : GenericCrudRepository<Student> ,IStudentRepository
    {
       private readonly ApplicationDbContext _context; 
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<List<Student>> GetAllAsync()
        //{
        //    var std =  await _context.Student.ToListAsync();
        //    return std;
        //}

        //public async Task<Student> GetAStudentAsync(string email)
        //{
        //    var aStudent = await _context.Student.FirstOrDefaultAsync(s=>s.Email == email);
        //    return aStudent;
        //}

        //public async Task<Student> InsertAsync(Student astudent)
        //{
        //    await _context.Student.AddAsync(astudent);
        //    var isInserted = await _context.SaveChangesAsync();
        //    return astudent;
        //}

        //public async Task<Student> UpdateAsync(string email, Student astudent)
        //{
        //    var student = await _context.Student.FirstOrDefaultAsync(s=>s.Email == email);

        //    if (student != null)
        //    {
        //        student.DepartmentId = astudent.DepartmentId;
        //        student.Name = astudent.Name;
        //        student.Email = astudent.Email;

        //        _context.Student.Update(student);
        //        var isUpdated = await _context.SaveChangesAsync();
        //    }

        //    return student;
        //}

        //public async Task<Student> DeleteAsync(string email)
        //{
        //    var student = await _context.Student.FirstOrDefaultAsync(s => s.Email == email);
        //    _context.Student.Remove(student);
        //    var isDeleted = await _context.SaveChangesAsync();
        //    return student;
        //}
    }
}
