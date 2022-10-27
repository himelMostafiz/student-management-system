using DLL.DBContext;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Repositories
{
    public class CourseStudentRepository : GenericCrudRepository<CourseStudent>, ICourseStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CourseStudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
