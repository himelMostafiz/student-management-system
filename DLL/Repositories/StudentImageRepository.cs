using DLL.DBContext;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Repositories
{
    public class StudentImageRepository : GenericCrudRepository<StudentImage>, IStudentImageRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentImageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
