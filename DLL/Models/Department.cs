using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
