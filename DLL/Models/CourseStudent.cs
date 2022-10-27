using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
