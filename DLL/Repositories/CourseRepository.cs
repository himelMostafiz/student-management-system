using DLL.DBContext;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Repositories
{
    public class CourseRepository : GenericCrudRepository<Course>,ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
