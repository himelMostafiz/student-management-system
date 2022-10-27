using DLL.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DLL.Models
{
    public class Course : ITrackable, ISoftDelete
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Credit { get; set; }
        public string FullName { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public ICollection<CourseStudent> CourseStudent { get; set; }
    }
}
