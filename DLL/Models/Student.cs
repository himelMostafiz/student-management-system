using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseStudent> CourseStudent { get; set; }
    }
}
